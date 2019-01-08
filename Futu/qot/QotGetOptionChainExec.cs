using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetOptionChainExec : IExecutor
    {
        private QotMarket market;
        private String symbol;
        private String beginTime;
        private String endTime;
        private int type;
        private int condition;

        private Qot_GetOptionChain.Response response;

        public static int nProtoID = 3209;

        public QotGetOptionChainExec(QotMarket market, String symbol, String beginTime, String endTime, int type, int condition)
        {
            this.market = market;
            this.symbol = symbol;
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.type = type;
            this.condition = condition;
        }



        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetOptionChain.Request.Builder request = Qot_GetOptionChain.Request.CreateBuilder();
            Qot_GetOptionChain.C2S.Builder c2s = Qot_GetOptionChain.C2S.CreateBuilder();
            c2s.SetOwner(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            c2s.BeginTime = beginTime;
            c2s.EndTime = endTime;
            if (type >= 0)
                c2s.Type = type;
            if (this.condition >= 0)
                c2s.Condition = condition;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetOptionChain.Response.ParseFrom(pack.Bodys);

        }


        public object getValue()
        {
            return response;
        }
    }
}
