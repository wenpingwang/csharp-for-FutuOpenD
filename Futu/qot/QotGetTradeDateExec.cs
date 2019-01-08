using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetTradeDateExec : IExecutor
    {
        public static int nProtoID = 3200;

        private Qot_GetTradeDate.Response response;

        private QotMarket market;

        private String beginTime;
        private String endTime;

        public QotGetTradeDateExec(QotMarket market, String beginTime, String endTime)
        {
            this.market = market;
            this.beginTime = beginTime;
            this.endTime = endTime;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetTradeDate.Request.Builder request = Qot_GetTradeDate.Request.CreateBuilder();
            Qot_GetTradeDate.C2S.Builder c2s = Qot_GetTradeDate.C2S.CreateBuilder();
            c2s.Market = (int)market;
            c2s.BeginTime = beginTime;
            c2s.EndTime = endTime;

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetTradeDate.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
