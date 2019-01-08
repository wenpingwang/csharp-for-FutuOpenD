using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class KeepAliveExec : IExecutor
    {
        public KeepAliveExec()
        {

        }
        public static int nProtoID = 1004;

        public ProtoBufPackage buildPackage()
        {
            KeepAlive.Request.Builder request = KeepAlive.Request.CreateBuilder();
            KeepAlive.C2S.Builder c2s = KeepAlive.C2S.CreateBuilder();
            c2s.Time = Utils.currentTimeMillis()/1000;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            pack.NBodyLen = pack.Bodys.Length;
            return pack;
        }

        public void execute(ProtoBufPackage pack)
        {
            KeepAlive.Response response = KeepAlive.Response.ParseFrom(pack.Bodys);
            Console.WriteLine(response);
        }

        public object getValue()
        {
            return null;
        }

        public int getnProtoID()
        {
            return nProtoID;
        }

    }
}
