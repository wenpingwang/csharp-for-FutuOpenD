using Qot_Common;
using System;
using System.Linq;

namespace Futu
{
    class QotGetKLExec : IUpdateExecutor
    {
        private Qot_GetKL.Response response;

        private QotMarket market;
        private String symbol;
        private RehabType rehabType;
        private KLType klType;
        private int reqNum;

        private IUpdateCallBack callback;

        public static int nProtoID = 3006;

        public static int nUpdateProtoID = 3007;

        public QotGetKLExec(QotMarket market, String symbol, RehabType rehabType, KLType klType, int reqNum, IUpdateCallBack callback)
        {
            this.market = market;
            this.symbol = symbol;
            this.rehabType = rehabType;
            this.klType = klType;
            this.reqNum = reqNum;
            if (this.reqNum > 1000)
                this.reqNum = 1000;
            this.callback = callback;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetKL.Request.Builder request = Qot_GetKL.Request.CreateBuilder();
            Qot_GetKL.C2S.Builder c2s = Qot_GetKL.C2S.CreateBuilder();
            c2s.KlType = (int)klType;
            c2s.RehabType = (int)rehabType;
            c2s.ReqNum = reqNum;
            c2s.SetSecurity(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetKL.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }


        public object parse(ProtoBufPackage pack)
        {
            return Qot_UpdateKL.Response.ParseFrom(pack.Bodys);
        }


        public void handler(object v)
        {
            Qot_UpdateKL.Response res = v as Qot_UpdateKL.Response;
            if (callback != null)
            {
                if (res.S2C.Security.Market == (int)this.market && res.S2C.Security.Code.Equals(this.symbol) &&
                    res.S2C.RehabType == (int)this.rehabType && res.S2C.KlType == (int)this.klType)
                {
                    callback.callback(res.S2C.KlListList.ToList());
                }
            }

        }


        public int getnUpdateProtoID()
        {
            return nUpdateProtoID;
        }
    }
}
