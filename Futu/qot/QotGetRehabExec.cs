using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetRehabExec : IExecutor
    {
        private QotMarket market;
        private String[] symbols;

        public static int nProtoID = 3102;

        private Qot_GetRehab.Response response;

        public QotGetRehabExec(QotMarket market, String[] symbols)
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
            Qot_GetRehab.Request.Builder request = Qot_GetRehab.Request.CreateBuilder();
            Qot_GetRehab.C2S.Builder c2s = Qot_GetRehab.C2S.CreateBuilder();
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
            response = Qot_GetRehab.Response.ParseFrom(pack.Bodys);

        }


        public object getValue()
        {
            return response;
        }

    }
}
