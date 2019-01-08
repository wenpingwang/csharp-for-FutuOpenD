using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetHoldingChangeListExec : IExecutor
    {
        private QotMarket market;
        private String symbol;
        private int holderCategory;
        private String beginTime;
        private String endTime;

        private Qot_GetHoldingChangeList.Response response;

        public static int nProtoID = 3208;

        public QotGetHoldingChangeListExec(QotMarket market, String symbol, int holderCategory, String beginTime, String endTime)
        {
            this.market = market;
            this.symbol = symbol;
            this.holderCategory = holderCategory;
            this.beginTime = beginTime;
            this.endTime = endTime;
        }



        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetHoldingChangeList.Request.Builder request = Qot_GetHoldingChangeList.Request.CreateBuilder();
            Qot_GetHoldingChangeList.C2S.Builder c2s = Qot_GetHoldingChangeList.C2S.CreateBuilder();
            c2s.SetSecurity(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            c2s.HolderCategory = holderCategory;
            if (beginTime != null)
                c2s.BeginTime = beginTime;
            if (endTime != null)
                c2s.EndTime = endTime;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetHoldingChangeList.Response.ParseFrom(pack.Bodys);

        }


        public object getValue()
        {
            return response;
        }

    }
}
