using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetOrderDetailExec : IUpdateExecutor
    {
        private QotMarket market;
        private String symbol;

        private Qot_GetOrderDetail.Response response;

        private IUpdateCallBack callback;

        public static int nProtoID = 3016;
        public static int nUpdateProtoID = 3017;

        public QotGetOrderDetailExec(QotMarket market, String symbol, IUpdateCallBack callback)
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
            Qot_GetOrderDetail.Request.Builder request = Qot_GetOrderDetail.Request.CreateBuilder();
            Qot_GetOrderDetail.C2S.Builder c2s = Qot_GetOrderDetail.C2S.CreateBuilder();
            c2s.SetSecurity(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetOrderDetail.Response.ParseFrom(pack.Bodys);

        }


        public object getValue()
        {
            return response;
        }



        public object parse(ProtoBufPackage pack)
        {
            return Qot_UpdateOrderDetail.Response.ParseFrom(pack.Bodys);
        }



        public void handler(object v)
        {
            Qot_UpdateOrderDetail.Response res = v as Qot_UpdateOrderDetail.Response;
            if (callback != null)
            {
                if (res.S2C.Security.Market == (int)this.market && res.S2C.Security.Code.Equals(this.symbol))
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.OrderDetailAsk1 = res.S2C.OrderDetailAsk;
                    orderDetails.OrderDetailBid1 = res.S2C.OrderDetailBid;
                    callback.callback(orderDetails);
                }
            }
        }



        public int getnUpdateProtoID()
        {
            return nUpdateProtoID;
        }

    }
}
