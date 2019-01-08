using Qot_Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Trd_Common;

namespace Futu
{
    class Program
    {
        private static Session session = null;

        static long futuUserID = 123456;

        static string pwdMD5 = "pwdmd5";//md5密码

        static TrdFilterConditions.Builder conditions = TrdFilterConditions.CreateBuilder();
        private static IExecutor handler;
        static void Main(string[] args)
        {
            //Client client = new Client();
            //client.setKeepAlive(false);
            //client.open("localhost", 11111);


            //send();
            //打开会话
            session = FutuOpenD.openSession("127.0.0.1", 11111, true);//true,启用推送功能
            conditions.BeginTime = new DateTime(2018, 8, 1, 0, 0, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");
            conditions.EndTime = new DateTime(2018, 8, 10, 0, 0, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");
            Thread.Sleep(1000);

            //获取账户资金 test
            //TraderSession traderSession = session.trdUnlockTradeForSimulate(futuUserID, pwdMD5);
            //Console.WriteLine(traderSession.trdGetFunds(TrdMarket.TrdMarket_HK));

            //3202获取股票静态信息
            //Console.WriteLine(session.qotGetStaticInfo(QotMarket.QotMarket_HK_Security, SecurityType.SecurityType_Bond, new String[] { }));

            //3203获取股票快照
            //Qot_GetSecuritySnapshot.Response securitySnapshotInfo = session.qotGetSecuritySnapshot(QotMarket.QotMarket_HK_Security, new String[] { "00939" });
            //Console.WriteLine(securitySnapshotInfo.S2C.SnapshotListList[0].Basic.HighPrice);
            //Console.WriteLine(securitySnapshotInfo.S2C.SnapshotListList[0].Basic.OpenPrice);

            //3001订阅或者反订阅
            Console.WriteLine(session.qotSub(QotMarket.QotMarket_CNSH_Security, new String[] { "000001" }, new SubType[] { SubType.SubType_Basic,SubType.SubType_Ticker }));
            //Thread.Sleep(1000);
            //3002注册行情推送
            //Console.WriteLine(session.qotRegQotPush(QotMarket.QotMarket_HK_Security, new String[] { "00700", "00005" }, new SubType[] { SubType.SubType_Ticker }, true, false));
            //Thread.Sleep(1000);
            Console.WriteLine(session.qotRegQotPush(QotMarket.QotMarket_CNSH_Security, new String[] { "000001" }, new SubType[] { SubType.SubType_Basic, SubType.SubType_Ticker },false,true));
            //Thread.Sleep(1000);
            //3003获取订阅信息
            //Console.WriteLine(session.qotGetSubInfo(false));
            //3004获取股票基本行情
            //session.stockBasicInfo(QotMarket.QotMarket_US_Security, new String[] { "AMZN" }, new BasicInfoCallback());
            //3010获取逐笔 3011推送逐笔
            session.qotGetTicker(QotMarket.QotMarket_CNSH_Security, "000001", 100, new TickerCallback());

            Console.ReadLine();
            //关闭会话
            session.close();
            
        }
        class BasicInfoCallback : IUpdateCallBack
        {
            void IUpdateCallBack.callback(object res)
            {
                List<Qot_Common.BasicQot> basicQots = res as List<Qot_Common.BasicQot>;
                Console.WriteLine(basicQots);
            }
        }
        class TickerCallback : IUpdateCallBack
        {
            void IUpdateCallBack.callback(object res)
            {
                List<Qot_Common.Ticker> tickers = res as List<Qot_Common.Ticker>;
                foreach(Qot_Common.Ticker ticker in tickers)
                {
                    Console.WriteLine(ticker);
                }
            }
        }

    }
}
