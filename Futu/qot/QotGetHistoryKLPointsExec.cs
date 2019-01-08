using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetHistoryKLPointsExec : IExecutor
    {
        private QotMarket market;
        private String[] symbols;
        private RehabType rehabType;
        private KLType klType;
        private Qot_GetHistoryKLPoints.NoDataMode noDataMode;
        private String[] timeLists;
        private int maxReqSecurityNum;
        private long needKLFieldsFlag;

        private Qot_GetHistoryKLPoints.Response response;

        public static int nProtoID = 3101;


        public QotGetHistoryKLPointsExec(QotMarket market, String[] symbols, RehabType rehabType, KLType klType, String[] timeLists, Qot_GetHistoryKLPoints.NoDataMode noDataMode, int maxReqSecurityNum, long needKLFieldsFlag)
        {
            this.market = market;
            this.symbols = symbols;
            this.rehabType = rehabType;
            this.klType = klType;
            this.noDataMode = noDataMode;
            this.timeLists = timeLists;
            this.maxReqSecurityNum = maxReqSecurityNum;
            this.needKLFieldsFlag = needKLFieldsFlag;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetHistoryKLPoints.Request.Builder request = Qot_GetHistoryKLPoints.Request.CreateBuilder();
            Qot_GetHistoryKLPoints.C2S.Builder c2s = Qot_GetHistoryKLPoints.C2S.CreateBuilder();
            foreach (String symbol in symbols)
                c2s.AddSecurityList(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            c2s.RehabType = (int)this.rehabType;
            c2s.KlType = (int)this.klType;
            c2s.NoDataMode = (int)noDataMode;
            int count = 0;
            foreach (String timeList in timeLists)
            {
                c2s.AddTimeList(timeList);
                count++;
                if (count == 5)
                    break;
            }
            if (maxReqSecurityNum > 0)
                c2s.MaxReqSecurityNum = maxReqSecurityNum;
            if (needKLFieldsFlag > 0)
                c2s.NeedKLFieldsFlag = needKLFieldsFlag;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetHistoryKLPoints.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }

    }
}
