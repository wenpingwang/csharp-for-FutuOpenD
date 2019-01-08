using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetStaticInfoExec : IExecutor
    {
        private QotMarket market;
        private String[] symbols;
        private SecurityType secType;
        private Qot_GetStaticInfo.Response response;

        public static int nProtoID = 3202;

        public QotGetStaticInfoExec(QotMarket market, String[] symbols, SecurityType secType)
        {
            this.market = market;
            this.symbols = symbols;
            this.secType = secType;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetStaticInfo.Request.Builder request = Qot_GetStaticInfo.Request.CreateBuilder();
            Qot_GetStaticInfo.C2S.Builder c2s = Qot_GetStaticInfo.C2S.CreateBuilder();
            c2s.Market = (int)market;
            c2s.SecType = (int)secType;
            if (symbols != null && symbols.Length > 0)
            {
                foreach (String symbol in symbols)
                    c2s.AddSecurityList(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            }

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetStaticInfo.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }

    }
}
