using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;

namespace Futu
{
    class TrdGetPositionListExec : IExecutor
    {
        private TrdEnv trdenv;
        private long accID;
        private TrdMarket trdMarket;

        private TrdFilterConditions filterConditions;
        private double? filterPLRatioMin;
        private double? filterPLRatioMax;

        private Trd_GetPositionList.Response response;

        public static int nProtoID = 2102;


        public TrdGetPositionListExec(TrdEnv trdenv, long accID, TrdMarket trdMarket, TrdFilterConditions filterConditions, double? filterPLRatioMin, double? filterPLRatioMax)
        {
            this.trdenv = trdenv;
            this.accID = accID;
            this.trdMarket = trdMarket;
            this.filterConditions = filterConditions;
            this.filterPLRatioMin = filterPLRatioMin;
            this.filterPLRatioMax = filterPLRatioMax;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Trd_GetPositionList.Request.Builder request = Trd_GetPositionList.Request.CreateBuilder();
            Trd_GetPositionList.C2S.Builder c2s = Trd_GetPositionList.C2S.CreateBuilder();
            TrdHeader.Builder headerBuilder = TrdHeader.CreateBuilder();
            headerBuilder.TrdEnv = (int)trdenv;
            headerBuilder.AccID = (ulong)accID;
            headerBuilder.TrdMarket = (int)trdMarket;
            c2s.SetHeader(headerBuilder.Build());
            if (filterConditions != null)
                c2s.FilterConditions = filterConditions;
            if (filterPLRatioMin != null)
                c2s.FilterPLRatioMin = (double)filterPLRatioMin;
            if (filterPLRatioMax != null)
                c2s.FilterPLRatioMax = (double)filterPLRatioMax;

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Trd_GetPositionList.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
