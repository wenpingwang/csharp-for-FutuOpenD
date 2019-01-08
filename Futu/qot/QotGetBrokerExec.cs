using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetBrokerExec : IUpdateExecutor
    {
        private QotMarket market;
        private String symbol;

        private Qot_GetBroker.Response response;

        private IUpdateCallBack callback;

        public static int nProtoID = 3014;

        public static int nUpdateProtoID = 3015;

        public QotGetBrokerExec(QotMarket market, String symbol, IUpdateCallBack callback)
        {
            this.market = market;
            this.symbol = symbol;
            this.callback = callback;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetBroker.Request.Builder request = Qot_GetBroker.Request.CreateBuilder();
            Qot_GetBroker.C2S.Builder c2s = Qot_GetBroker.C2S.CreateBuilder();
            c2s.SetSecurity(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetBroker.Response.ParseFrom(pack.Bodys);

        }


        public object getValue()
        {
            return response;
        }


        public object parse(ProtoBufPackage pack)
        {
            return Qot_GetBroker.Response.ParseFrom(pack.Bodys);
        }


        public void handler(object v)
        {
            Qot_GetBroker.Response res = v as Qot_GetBroker.Response;
            if (callback != null)
            {
                if (res.S2C.Security.Market == (int)this.market && res.S2C.Security.Code.Equals(this.symbol))
                {
                    Brokers brokers = new Brokers();
                    brokers.BrokerAskList = res.S2C.BrokerAskListList.ToList();
                    brokers.BrokerBidList = res.S2C.BrokerBidListList.ToList();
                    callback.callback(brokers);
                }
            }
        }


        public int getnUpdateProtoID()
        {
            return nUpdateProtoID;
        }
    }
}
