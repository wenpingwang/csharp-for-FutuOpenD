using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Futu
{
    class Client
    {
        private Dictionary<int, IExecutor> handlers = new Dictionary<int, IExecutor>();//包序列号，对应请求包和回包

        private long connID;
        private string ip;
        private int port;
        private Socket socket = null;
        private MemoryStream ms = null;
        private bool keepAlive = true;
        private bool over = false;//socket.close
        private bool connected = false;

        public Client()
        {

        }

        public void open(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            try
            {
                initConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
            }
            Thread heartbeatThread = new Thread(SocketThread);
            heartbeatThread.IsBackground = true;
            heartbeatThread.Start();

            IExecutor handler = null;
            foreach (IExecutor exec in handlers.Values)
            {
                if (exec.getnProtoID() == InitConnectExec.nProtoID)
                {
                    handler = exec;
                    break;
                }
            }

            long startTime = Utils.currentTimeMillis();
            while (handler.getValue() == null)
            {
                if ((Utils.currentTimeMillis() - startTime) > 30 * 1000)//超时
                    break;
                sleepMillis(1);
            }
            InitConnect.Response res = (InitConnect.Response)handler.getValue();
            connID = (long)res.S2C.ConnID;
            //Console.WriteLine(connID);
        }

        public object execute(IExecutor handler)
        {
            ProtoBufPackage pack = handler.buildPackage();
            addHander(pack.NSerialNo, handler);
            while (!over)
            {
                if (connected)
                {
                    try
                    {
                        socket.Send(pack.pack());
                        ms.Flush();
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.GetBaseException());
                    }
                    break;
                }
                sleepMillis(1);
            }
            long startTime = Utils.currentTimeMillis();
            while (handler.getValue() == null)
            {
                if ((Utils.currentTimeMillis() - startTime) > 30 * 1000)//超时
                    break;
                sleepMillis(1);
            }
            return handler.getValue();
        }

        private void addHander(int nSerialNo, IExecutor handler)
        {
            if (handlers.ContainsKey(nSerialNo))
            {
                handlers[nSerialNo] = handler;
            }
            else
            {
                handlers.Add(nSerialNo, handler);
            }
        }

        public void close()
        {
            over = true;
        }

        /**
         * 初始化协议
         * @throws UnknownHostException
         * @throws IOException
         */
        public void initConnection()
        {
            ms = new MemoryStream();
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAdd = IPAddress.Parse(ip); ;
            IPEndPoint point = new IPEndPoint(ipAdd, port);
            socket.Connect(point);
            InitConnectExec init = new InitConnectExec();
            ProtoBufPackage pack = init.buildPackage();

            this.addHander(pack.NSerialNo, init);
            socket.Send(pack.pack());
            ms.Flush();

        }
        /**
         * 发送心跳包
         */
        public void sendHeartbeat()
        {
            while (!over && keepAlive)
            {
                try
                {
                    sleepMillis(10 * 1000);// 10s发送一次心跳
                    KeepAliveExec keepAlive = new KeepAliveExec();
                    ProtoBufPackage pack = keepAlive.buildPackage();
                    addHander(pack.NSerialNo, keepAlive);
                    socket.Send(pack.pack());
                    ms.Flush();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void SocketThread()
        {
            Thread heartbeatThread = new Thread(sendHeartbeat);
            heartbeatThread.IsBackground = true;
            heartbeatThread.Start();
            long startTime = Utils.currentTimeMillis();

            while (!over)
            {
                try
                {
                    int size = socket.Available;
                    if (size <= 0)
                    {
                        if ((Utils.currentTimeMillis() - startTime) > 30 * 1000)
                        { // 超过30秒没有收到服务器信息，关闭
                            socket.Close();
                            startTime = Utils.currentTimeMillis();
                        }
                        sleepMillis(1);
                        continue;
                    }
                    else
                    {
                        startTime = Utils.currentTimeMillis();
                        byte[] buffer = new byte[socket.Available];
                        var effective = socket.Receive(buffer);
                        MemoryStream ms = new MemoryStream();
                        ms.Write(buffer, 0, buffer.Length);
                        ProtoBufPackage pack = ProtoBufPackage.unpack(ms);
                        if (pack.NProtoID == InitConnectExec.nProtoID)
                        {
                            connected = true;
                        }
                        Thread handlerThread = new Thread(handler);
                        handlerThread.IsBackground = true;
                        handlerThread.Start(pack);
                    }
                }
                catch (Exception e)
                {
                    over = true;
                }
            }
            handlers = null;
            socket.Close();
            ms.Close();
        }

        public void handler(object v)
        {
            ProtoBufPackage pack = v as ProtoBufPackage;

            IExecutor handler = null;
            
            handlers.TryGetValue(pack.NSerialNo,out handler);
            try
            {
                if (handler != null)
                {
                    handler.execute(pack);
                }
                else
                {
                    foreach (IExecutor exec in handlers.Values)
                    {
                        if (typeof(IUpdateExecutor).IsAssignableFrom(exec.GetType()))
                        {
                            IUpdateExecutor upexec = ((IUpdateExecutor)exec);
                            if (((IUpdateExecutor)exec).getnUpdateProtoID() == pack.NProtoID)
                            {
                                upexec.handler(upexec.parse(pack));
                                if (pack.NProtoID == TrdGetOrderFillListExec.nUpdateProtoID || pack.NProtoID == TrdPlaceOrderExec.nUpdateProtoID)//与交易相关的推送是全局推送，不需要根据条件过滤。只需要推送一次就可以了。2208推送订单更新,2218推送新成交
                                    break;
                            }
                        }
                    }
                }
            }catch(Exception e)
            {
                over = true;
            }
        }

        public void sleepMillis(int millis)
        {
            Thread.Sleep(millis);
        }


        internal long getConnID()
        {
            return connID;
        }


        public long ConnID { get => connID; set => connID = value; }
        public string Ip { get => ip; set => ip = value; }
        public int Port { get => port; set => port = value; }
        public Socket Socket { get => socket; set => socket = value; }
        public MemoryStream Ms { get => ms; set => ms = value; }
        public bool KeepAlive { get => keepAlive; set => keepAlive = value; }
        public bool Over { get => over; set => over = value; }
        public bool Connected { get => connected; set => connected = value; }
    }
}
