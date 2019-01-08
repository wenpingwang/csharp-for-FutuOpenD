using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class GetGlobalStateExec : IExecutor
    {
        public static int nProtoID = 1002;

        private long futuUserID;

        GetGlobalState.Response response;

        public GetGlobalStateExec(long futuUserID)
        {
            this.futuUserID = futuUserID;
        }

        public ProtoBufPackage buildPackage()
        {
            GetGlobalState.Request.Builder request = GetGlobalState.Request.CreateBuilder();
            GetGlobalState.C2S.Builder c2s = GetGlobalState.C2S.CreateBuilder();
            c2s.UserID = (ulong)futuUserID;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = GetGlobalState.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }
    }
}
