using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetTickerExec : IUpdateExecutor
    {
        private Qot_GetTicker.Response response;

        private QotMarket market;
        private String symbol;
        private int maxRetNum = 100;
        private IUpdateCallBack callback;

        public static int nProtoID = 3010;

        public static int nUpdateProtoID = 3011;

        public QotGetTickerExec(QotMarket market, String symbol, int maxRetNum, IUpdateCallBack callback)
        {
            this.market = market;
            this.symbol = symbol;
            this.maxRetNum = maxRetNum;
            if (maxRetNum > 1000)
                this.maxRetNum = 1000;
            this.callback = callback;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetTicker.Request.Builder request = Qot_GetTicker.Request.CreateBuilder();
            Qot_GetTicker.C2S.Builder c2s = Qot_GetTicker.C2S.CreateBuilder();
            Security.Builder security = Security.CreateBuilder();
            security.Market = (int)market;
            security.Code = symbol;
            c2s.SetSecurity(security);
            c2s.MaxRetNum = maxRetNum;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetTicker.Response.ParseFrom(pack.Bodys);

        }


        public object getValue()
        {
            return response;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public object parse(ProtoBufPackage pack)
        {
            return Qot_GetTicker.Response.ParseFrom(pack.Bodys);
        }


        public void handler(object v)
        {
            Qot_GetTicker.Response res = v as Qot_GetTicker.Response;
            if (callback != null)
            {
                int market = res.S2C.Security.Market;
                String symbol = res.S2C.Security.Code;
                if ((int)this.market == market && this.symbol.Equals(symbol))
                    callback.callback(res.S2C.TickerListList.ToList());
            }
        }


        public int getnUpdateProtoID()
        {
            return nUpdateProtoID;
        }
    }
}
