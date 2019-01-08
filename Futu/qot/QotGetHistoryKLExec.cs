using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetHistoryKLExec : IExecutor
    {
        private QotMarket market;
        private String symbol;
        private RehabType rehabType;
        private KLType klType;
        private int maxAckKLNum;
        private String beginTime;
        private String endTime;
        private long needKLFieldsFlag;

        private Qot_GetHistoryKL.Response response;

        public static int nProtoID = 3100;


        /**
         * 
         * @param market
         * @param symbol
         * @param rehabType
         * @param klType
         * @param beginTime
         * @param endTime
         * @param maxAckKLNum
         * @param needKLFieldsFlag
         */
        public QotGetHistoryKLExec(QotMarket market, String symbol, RehabType rehabType, KLType klType, String beginTime, String endTime, int maxAckKLNum, long needKLFieldsFlag)
        {
            this.market = market;
            this.symbol = symbol;
            this.rehabType = rehabType;
            this.klType = klType;
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.maxAckKLNum = maxAckKLNum;
            this.needKLFieldsFlag = needKLFieldsFlag;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetHistoryKL.Request.Builder request = Qot_GetHistoryKL.Request.CreateBuilder();
            Qot_GetHistoryKL.C2S.Builder c2s = Qot_GetHistoryKL.C2S.CreateBuilder();
            c2s.SetSecurity(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            c2s.RehabType = (int)this.rehabType;
            c2s.KlType = (int)this.klType;
            c2s.BeginTime = beginTime;
            c2s.EndTime = endTime;
            if (this.maxAckKLNum > 0)
                c2s.MaxAckKLNum = maxAckKLNum;
            if (this.needKLFieldsFlag > 0)
                c2s.NeedKLFieldsFlag = needKLFieldsFlag;

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetHistoryKL.Response.ParseFrom(pack.Bodys);

        }


        public object getValue()
        {
            return response;
        }
    }
}
