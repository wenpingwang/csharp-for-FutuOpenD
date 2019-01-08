using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;

namespace Futu
{
    class TrdGetOrderListExec : IExecutor
    {
        private TrdEnv trdenv;
        private long accID;
        private TrdMarket trdMarket;

        private TrdFilterConditions filterConditions;
        private int[] filterStatusList;

        private Trd_GetOrderList.Response response;

        public static int nProtoID = 2201;


        public TrdGetOrderListExec(TrdEnv trdenv, long accID, TrdMarket trdMarket, TrdFilterConditions filterConditions, int[] filterStatusList)
        {
            this.trdenv = trdenv;
            this.accID = accID;
            this.trdMarket = trdMarket;
            this.filterConditions = filterConditions;
            this.filterStatusList = filterStatusList;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Trd_GetOrderList.Request.Builder request = Trd_GetOrderList.Request.CreateBuilder();
            Trd_GetOrderList.C2S.Builder c2s = Trd_GetOrderList.C2S.CreateBuilder();
            TrdHeader.Builder headerBuilder = TrdHeader.CreateBuilder();
            headerBuilder.TrdEnv = (int)trdenv;
            headerBuilder.AccID = (ulong)accID;
            headerBuilder.TrdMarket = (int)trdMarket;
            c2s.SetHeader(headerBuilder.Build());
            if (filterConditions != null)
                c2s.FilterConditions = filterConditions;
            if (filterStatusList != null && filterStatusList.Length > 0)
            {
                foreach (int orderID in filterStatusList)
                    c2s.AddFilterStatusList(orderID);
            }


            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Trd_GetOrderList.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
