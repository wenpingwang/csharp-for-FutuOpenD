using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;

namespace Futu
{
    class TrdPlaceOrderExec:IExecutor
    {
        private TrdEnv trdenv;
        private long accID;
        private TrdMarket trdMarket;
        private TrdSide trdSide;
        private OrderType orderType;
        private String code;
        private double qty;
        private double price;
        private Object adjustPrice;
        private Object adjustSideAndLimit;
        private long connID;

        private Trd_PlaceOrder.Response response;

        private IUpdateCallBack callback;

        public static int nProtoID = 2202;

        public static int nUpdateProtoID = 2208;

        public TrdPlaceOrderExec(TrdEnv trdenv, long accID, TrdMarket trdMarket, TrdSide trdSide, OrderType orderType, String code, double qty, double price, Object adjustPrice, Object adjustSideAndLimit, long connID, IUpdateCallBack callback)
        {
            this.trdenv = trdenv;
            this.accID = accID;
            this.trdMarket = trdMarket;
            this.trdSide = trdSide;
            this.orderType = orderType;
            this.code = code;
            this.qty = qty;
            this.price = price;
            this.adjustPrice = adjustPrice;
            this.adjustSideAndLimit = adjustSideAndLimit;
            this.connID = connID;
        }
        
    public int getnProtoID()
        {
            return nProtoID;
        }
        
    public ProtoBufPackage buildPackage()
        {
            Trd_PlaceOrder.Request.Builder request = Trd_PlaceOrder.Request.CreateBuilder();
            Trd_PlaceOrder.C2S.Builder c2s = Trd_PlaceOrder.C2S.CreateBuilder();

            ProtoBufPackage pack = new ProtoBufPackage();

            TrdHeader.Builder headerBuilder = TrdHeader.CreateBuilder();
            headerBuilder.TrdEnv= (int)trdenv;
            headerBuilder.AccID=(ulong)accID;
            headerBuilder.TrdMarket=(int)trdMarket;
            c2s.Header=headerBuilder.Build();

            PacketID.Builder packetID = PacketID.CreateBuilder();
            packetID.ConnID=(ulong)connID;
            packetID.SerialNo=(uint)pack.NSerialNo;

            c2s.PacketID=packetID.Build();
            c2s.TrdSide=(int)trdSide;
            c2s.OrderType=(int)orderType;
            c2s.Code=code;
            c2s.Qty=qty;
            c2s.Price=price;
            if (adjustPrice != null)
                c2s.AdjustPrice=(bool)adjustPrice;
            if (adjustSideAndLimit != null)
                c2s.AdjustSideAndLimit=(double)adjustSideAndLimit;


            request.SetC2S(c2s);

            pack.NProtoID=nProtoID;

            pack.Bodys=request.Build().ToByteArray();
            return pack;
        }
        
    public void execute(ProtoBufPackage pack) 
        {
            response = Trd_PlaceOrder.Response.ParseFrom(pack.Bodys);
	}
    
    public object getValue()
    {
        return response;
    }
    
    public Trd_UpdateOrder.Response parse(ProtoBufPackage pack) 
    {
		return Trd_UpdateOrder.Response.ParseFrom(pack.Bodys);
    }
    
    public void handler(Trd_UpdateOrder.Response res)
    {
        if (callback != null)
        {
            callback.callback(res);
        }
    }
    
    public int getnUpdateProtoID()
    {
        return nUpdateProtoID;
    }

}
}
