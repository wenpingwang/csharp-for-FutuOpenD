using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetPlateSecurityExec : IExecutor
    {
        private QotMarket market;
        private String symbol;

        private Qot_GetPlateSecurity.Response response;

        public static int nProtoID = 3205;


        public QotGetPlateSecurityExec(QotMarket market, String symbol)
        {
            this.market = market;
            this.symbol = symbol;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetPlateSecurity.Request.Builder request = Qot_GetPlateSecurity.Request.CreateBuilder();
            Qot_GetPlateSecurity.C2S.Builder c2s = Qot_GetPlateSecurity.C2S.CreateBuilder();
            c2s.SetPlate(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetPlateSecurity.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
