using Google.ProtocolBuffers;
using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotRequestHistoryKLExec : IExecutor
    {
        private QotMarket market;
        private String symbol;
        private RehabType rehabType;
        private KLType klType;
        private int maxAckKLNum;
        private String beginTime;
        private String endTime;
        private long needKLFieldsFlag;
        private String nextReqKey;

        private Qot_RequestHistoryKL.Response response;

        public static int nProtoID = 3103;


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
         * @param nextReqKey  分页请求的key。如果start和end之间的数据点多于max_count，那么后续请求时，要传入上次调用返回的page_req_key。初始请求时应该传None。
         */
        public QotRequestHistoryKLExec(QotMarket market, String symbol, RehabType rehabType, KLType klType, String beginTime, String endTime, int maxAckKLNum, long needKLFieldsFlag, String nextReqKey)
        {
            this.market = market;
            this.symbol = symbol;
            this.rehabType = rehabType;
            this.klType = klType;
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.maxAckKLNum = maxAckKLNum;
            this.needKLFieldsFlag = needKLFieldsFlag;
            this.nextReqKey = nextReqKey;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_RequestHistoryKL.Request.Builder request = Qot_RequestHistoryKL.Request.CreateBuilder();
            Qot_RequestHistoryKL.C2S.Builder c2s = Qot_RequestHistoryKL.C2S.CreateBuilder();
            c2s.SetSecurity(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            c2s.RehabType = (int)this.rehabType;
            c2s.KlType = (int)this.klType;
            c2s.BeginTime = beginTime;
            c2s.EndTime = endTime;
            if (this.maxAckKLNum > 0)
                c2s.MaxAckKLNum = maxAckKLNum;
            if (this.needKLFieldsFlag > 0)
                c2s.NeedKLFieldsFlag = needKLFieldsFlag;
            if (nextReqKey == null || nextReqKey.Trim().Equals(""))
                c2s.NextReqKey = ByteString.CopyFromUtf8("None");
            else
                c2s.NextReqKey = ByteString.CopyFromUtf8(nextReqKey);

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_RequestHistoryKL.Response.ParseFrom(pack.Bodys);

        }


        public object getValue()
        {
            return response;
        }

    }
}
