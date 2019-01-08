using System;

namespace Futu
{
    class InitConnectExec : IExecutor
    {
        private InitConnect.Response response;

        public static int nProtoID = 1001;

        public ProtoBufPackage buildPackage()
        {
            InitConnect.Request.Builder request = InitConnect.Request.CreateBuilder();
            InitConnect.C2S.Builder c2s = InitConnect.C2S.CreateBuilder();
            c2s.SetClientID("testcshap");
            c2s.SetClientVer(307);
            c2s.SetRecvNotify(true);
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            pack.NBodyLen = pack.Bodys.Length;
            return pack;
        }

        public void execute(ProtoBufPackage pack)
        {
            response = InitConnect.Response.ParseFrom(pack.Bodys);
            //Console.WriteLine(response);
        }


        public Object getValue()
        {
            return response;
        }

        public int getnProtoID()
        {
            return nProtoID;
        }

    }
}
