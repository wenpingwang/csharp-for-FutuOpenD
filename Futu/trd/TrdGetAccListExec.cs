using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class TrdGetAccListExec : IExecutor
    {
        private long futuUserID;

        private Trd_GetAccList.Response response;

        public static int nProtoID = 2001;

        public TrdGetAccListExec(long futuUserID)
        {
            this.futuUserID = futuUserID;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Trd_GetAccList.Request.Builder request = Trd_GetAccList.Request.CreateBuilder();
            Trd_GetAccList.C2S.Builder c2s = Trd_GetAccList.C2S.CreateBuilder();
            c2s.UserID = (ulong)futuUserID;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Trd_GetAccList.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
