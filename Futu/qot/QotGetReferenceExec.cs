using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetReferenceExec : IExecutor
    {
        private QotMarket market;
        private String symbol;

        private Qot_GetReference.ReferenceType referenceType;

        private Qot_GetReference.Response response;

        public static int nProtoID = 3206;

        public QotGetReferenceExec(QotMarket market, String symbol, Qot_GetReference.ReferenceType referenceType)
        {
            this.market = market;
            this.symbol = symbol;
            this.referenceType = referenceType;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetReference.Request.Builder request = Qot_GetReference.Request.CreateBuilder();
            Qot_GetReference.C2S.Builder c2s = Qot_GetReference.C2S.CreateBuilder();
            c2s.SetSecurity(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            c2s.ReferenceType = (int)referenceType;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetReference.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
