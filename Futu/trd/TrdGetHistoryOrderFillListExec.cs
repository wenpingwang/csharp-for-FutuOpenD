using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;

namespace Futu
{
    class TrdGetHistoryOrderFillListExec : IExecutor
    {
        private TrdEnv trdenv;
        private long accID;
        private TrdMarket trdMarket;

        private TrdFilterConditions filterConditions;

        private Trd_GetHistoryOrderFillList.Response response;

        public static int nProtoID = 2222;


        public TrdGetHistoryOrderFillListExec(TrdEnv trdenv, long accID, TrdMarket trdMarket, TrdFilterConditions filterConditions)
        {
            this.trdenv = trdenv;
            this.accID = accID;
            this.trdMarket = trdMarket;
            this.filterConditions = filterConditions;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Trd_GetHistoryOrderFillList.Request.Builder request = Trd_GetHistoryOrderFillList.Request.CreateBuilder();
            Trd_GetHistoryOrderFillList.C2S.Builder c2s = Trd_GetHistoryOrderFillList.C2S.CreateBuilder();
            TrdHeader.Builder headerBuilder = TrdHeader.CreateBuilder();
            headerBuilder.TrdEnv = (int)trdenv;
            headerBuilder.AccID = (ulong)accID;
            headerBuilder.TrdMarket = (int)trdMarket;
            c2s.SetHeader(headerBuilder.Build());
            c2s.FilterConditions = filterConditions;

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Trd_GetHistoryOrderFillList.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
