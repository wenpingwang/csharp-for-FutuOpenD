using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;

namespace Futu
{
    class TrdModifyOrderExec : IExecutor
    {
        private TrdEnv trdenv;
        private long accID;
        private TrdMarket trdMarket;
        private long orderID;
        private ModifyOrderOp modifyOrderOp;
        private bool? forAll;
        private double? qty;
        private double? price;
        private bool? adjustPrice;
        private double? adjustSideAndLimit;
        private long connID;

        private Trd_ModifyOrder.Response response;

        public static int nProtoID = 2205;

        public TrdModifyOrderExec(TrdEnv trdenv, long accID, TrdMarket trdMarket, long orderID, ModifyOrderOp modifyOrderOp, bool? forAll, double? qty, double? price, bool? adjustPrice, double? adjustSideAndLimit, long connID)
        {
            this.trdenv = trdenv;
            this.accID = accID;
            this.trdMarket = trdMarket;
            this.orderID = orderID;
            this.modifyOrderOp = modifyOrderOp;
            this.forAll = forAll;
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
            Trd_ModifyOrder.Request.Builder request = Trd_ModifyOrder.Request.CreateBuilder();
            Trd_ModifyOrder.C2S.Builder c2s = Trd_ModifyOrder.C2S.CreateBuilder();

            ProtoBufPackage pack = new ProtoBufPackage();

            TrdHeader.Builder headerBuilder = TrdHeader.CreateBuilder();
            headerBuilder.TrdEnv = (int)trdenv;
            headerBuilder.AccID = (ulong)accID;
            headerBuilder.TrdMarket = (int)trdMarket;
            c2s.SetHeader(headerBuilder.Build());

            PacketID.Builder packetID = PacketID.CreateBuilder();
            packetID.ConnID = (ulong)connID;
            packetID.SerialNo = (uint)pack.NSerialNo;

            c2s.SetPacketID(packetID.Build());
            c2s.OrderID = (ulong)orderID;
            c2s.ModifyOrderOp = (int)modifyOrderOp;
            if (forAll != null)
                c2s.ForAll = (bool)forAll;
            if (qty != null)
                c2s.Qty = (double)qty;
            if (price != null)
                c2s.Price = (double)price;
            if (adjustPrice != null)
                c2s.AdjustPrice = (bool)adjustPrice;
            if (adjustSideAndLimit != null)
                c2s.AdjustSideAndLimit = (double)adjustSideAndLimit;

            request.SetC2S(c2s);
            pack.NProtoID = nProtoID;

            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Trd_ModifyOrder.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
