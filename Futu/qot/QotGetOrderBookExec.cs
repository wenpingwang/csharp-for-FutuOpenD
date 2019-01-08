using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetOrderBookExec : IUpdateExecutor
    {
        public static int nProtoID = 3012;

        public static int nUpdateProtoID = 3013;

        private QotMarket market;
        private String symbol;
        private int num;

        private Qot_GetOrderBook.Response response;

        private IUpdateCallBack callback;

        public QotGetOrderBookExec(QotMarket market, String symbol, int num, IUpdateCallBack callback)
        {
            this.market = market;
            this.symbol = symbol;
            this.num = num;
            if (this.num > 10)
                this.num = 10;
            this.callback = callback;
        }



        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetOrderBook.Request.Builder request = Qot_GetOrderBook.Request.CreateBuilder();
            Qot_GetOrderBook.C2S.Builder c2s = Qot_GetOrderBook.C2S.CreateBuilder();
            c2s.SetSecurity(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            c2s.Num = num;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetOrderBook.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }


        public object parse(ProtoBufPackage pack)
        {
            return Qot_GetOrderBook.Response.ParseFrom(pack.Bodys);
        }


        public void handler(object v)
        {
            Qot_GetOrderBook.Response res = v as Qot_GetOrderBook.Response;
            if (this.callback != null)
            {
                if (res.S2C.Security.Market == (int)this.market && res.S2C.Security.Code.Equals(this.symbol))
                {
                    OrderBooks orderBooks = new OrderBooks();
                    orderBooks.OrderBookBidList = res.S2C.OrderBookBidListList.ToList();
                    orderBooks.OrderBookAskList = res.S2C.OrderBookAskListList.ToList();
                    callback.callback(orderBooks);
                }
            }
        }


        public int getnUpdateProtoID()
        {
            return nUpdateProtoID;
        }
    }
}
