using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;

namespace Futu
{
    class TrdGetFundsExec : IExecutor
    {
        private TrdEnv trdenv;
        private long accID;
        private TrdMarket trdMarket;

        private Trd_GetFunds.Response response;

        public static int nProtoID = 2101;


        public TrdGetFundsExec(TrdEnv trdenv, long accID, TrdMarket trdMarket)
        {
            this.trdenv = trdenv;
            this.accID = accID;
            this.trdMarket = trdMarket;
        }

        public int getnProtoID()
        {
            return nProtoID;
        }

        public ProtoBufPackage buildPackage()
        {
            Trd_GetFunds.Request.Builder request = Trd_GetFunds.Request.CreateBuilder();
            Trd_GetFunds.C2S.Builder c2s = Trd_GetFunds.C2S.CreateBuilder();
            TrdHeader.Builder headerBuilder = TrdHeader.CreateBuilder();
            headerBuilder.TrdEnv = (int)trdenv;
            headerBuilder.AccID = (ulong)accID;
            headerBuilder.TrdMarket = (int)trdMarket;
            c2s.Header = headerBuilder.Build();

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }

        public void execute(ProtoBufPackage pack)
        {
            response = Trd_GetFunds.Response.ParseFrom(pack.Bodys);
            //Console.WriteLine(response);
        }


        public object getValue()
        {
            return response;
        }
    }
}
