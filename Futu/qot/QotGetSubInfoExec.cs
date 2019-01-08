using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetSubInfoExec : IExecutor
    {
        private bool isReqAllConn;

        private Qot_GetSubInfo.Response response;

        public static int nProtoID = 3003;

        public QotGetSubInfoExec(bool isReqAllConn)
        {
            this.isReqAllConn = isReqAllConn;
        }

        public ProtoBufPackage buildPackage()
        {
            Qot_GetSubInfo.Request.Builder request = Qot_GetSubInfo.Request.CreateBuilder();
            Qot_GetSubInfo.C2S.Builder c2s = Qot_GetSubInfo.C2S.CreateBuilder();
            c2s.IsReqAllConn = isReqAllConn;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetSubInfo.Response.ParseFrom(pack.Bodys);
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
