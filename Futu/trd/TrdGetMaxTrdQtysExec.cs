using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;

namespace Futu
{
    class TrdGetMaxTrdQtysExec : IExecutor
    {
        private TrdEnv trdenv;
        private long accID;
        private TrdMarket trdMarket;

        private OrderType orderType;
        private String code;
        private double price;
        private long? orderID;
        private bool? adjustPrice;
        private double? adjustSideAndLimit;

        private Trd_GetMaxTrdQtys.Response response;

        public static int nProtoID = 2111;


        public TrdGetMaxTrdQtysExec(TrdEnv trdenv, long accID, TrdMarket trdMarket, OrderType orderType, String code, double price, long? orderID, bool? adjustPrice, double? adjustSideAndLimit)
        {
            this.trdenv = trdenv;
            this.accID = accID;
            this.trdMarket = trdMarket;
            this.orderType = orderType;
            this.code = code;
            this.price = price;
            this.orderID = orderID;
            this.adjustPrice = adjustPrice;
            this.adjustSideAndLimit = adjustSideAndLimit;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Trd_GetMaxTrdQtys.Request.Builder request = Trd_GetMaxTrdQtys.Request.CreateBuilder();
            Trd_GetMaxTrdQtys.C2S.Builder c2s = Trd_GetMaxTrdQtys.C2S.CreateBuilder();
            TrdHeader.Builder headerBuilder = TrdHeader.CreateBuilder();
            headerBuilder.TrdEnv = (int)trdenv;
            headerBuilder.AccID = (ulong)accID;
            headerBuilder.TrdMarket = (int)trdMarket;
            c2s.SetHeader(headerBuilder.Build());
            c2s.OrderType = (int)orderType;
            c2s.Code = code;
            c2s.Price = price;
            if (orderID != null)
                c2s.OrderID = (ulong)orderID;
            if (adjustPrice != null)
                c2s.AdjustPrice = (bool)adjustPrice;
            if (adjustSideAndLimit != null)
                c2s.AdjustSideAndLimit = (double)adjustSideAndLimit;

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Trd_GetMaxTrdQtys.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
