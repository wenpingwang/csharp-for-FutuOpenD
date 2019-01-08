using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetOwnerPlateExec : IExecutor
    {
        private QotMarket market;
        private String[] symbols;

        private Qot_GetOwnerPlate.Response response;

        public static int nProtoID = 3207;

        public QotGetOwnerPlateExec(QotMarket market, String[] symbols)
        {
            this.market = market;
            this.symbols = symbols;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetOwnerPlate.Request.Builder request = Qot_GetOwnerPlate.Request.CreateBuilder();
            Qot_GetOwnerPlate.C2S.Builder c2s = Qot_GetOwnerPlate.C2S.CreateBuilder();
            foreach (String symbol in symbols)
                c2s.AddSecurityList(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetOwnerPlate.Response.ParseFrom(pack.Bodys);

        }


        public object getValue()
        {
            return response;
        }

    }
}
