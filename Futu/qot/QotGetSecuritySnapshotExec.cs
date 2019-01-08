using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetSecuritySnapshotExec : IExecutor
    {
        private QotMarket market;
        private String[] symbols;

        private Qot_GetSecuritySnapshot.Response response;

        public static int nProtoID = 3203;

        public QotGetSecuritySnapshotExec(QotMarket market, String[] symbols)
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
            Qot_GetSecuritySnapshot.Request.Builder request = Qot_GetSecuritySnapshot.Request.CreateBuilder();
            Qot_GetSecuritySnapshot.C2S.Builder c2s = Qot_GetSecuritySnapshot.C2S.CreateBuilder();
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
            response = Qot_GetSecuritySnapshot.Response.ParseFrom(pack.Bodys);
        }


        public Object getValue()
        {
            return response;
        }
    }
}
