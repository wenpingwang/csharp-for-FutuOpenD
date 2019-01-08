using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetRTExec : IUpdateExecutor
    {
        private QotMarket market;
        private String symbol;

        private Qot_GetRT.Response response;

        private IUpdateCallBack callback;

        public static int nProtoID = 3008;

        public static int nUpdateProtoID = 3009;

        public QotGetRTExec(QotMarket market, String symbol, IUpdateCallBack callback)
        {
            this.market = market;
            this.symbol = symbol;
            this.callback = callback;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetRT.Request.Builder request = Qot_GetRT.Request.CreateBuilder();
            Qot_GetRT.C2S.Builder c2s = Qot_GetRT.C2S.CreateBuilder();
            c2s.SetSecurity(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetRT.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }


        public object parse(ProtoBufPackage pack)
        {
            return Qot_GetRT.Response.ParseFrom(pack.Bodys);
        }


        public void handler(object v)
        {
            Qot_GetRT.Response res = v as Qot_GetRT.Response;
            if (this.callback != null)
            {
                if (res.S2C.Security.Market == (int)this.market && res.S2C.Security.Code.Equals(this.symbol))
                    callback.callback(res.S2C.RtListList.ToList());
            }

        }


        public int getnUpdateProtoID()
        {
            return nUpdateProtoID;
        }
    }
}
