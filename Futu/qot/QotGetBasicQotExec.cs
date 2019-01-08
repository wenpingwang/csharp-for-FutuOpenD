using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetBasicQotExec : IUpdateExecutor
    {
        private Qot_GetBasicQot.Response response;

        private QotMarket market;
        private String[] symbols;

        private IUpdateCallBack callback;

        public static int nProtoID = 3004;

        public static int nUpdateProtoID = 3005;

        public QotGetBasicQotExec(QotMarket market, String[] symbols, IUpdateCallBack callback)
        {
            this.market = market;
            this.symbols = symbols;
            this.callback = callback;
        }

        public ProtoBufPackage buildPackage()
        {
            Qot_GetBasicQot.Request.Builder request = Qot_GetBasicQot.Request.CreateBuilder();
            Qot_GetBasicQot.C2S.Builder c2s = Qot_GetBasicQot.C2S.CreateBuilder();
            foreach (String symbol in symbols)
                c2s.AddSecurityList(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }



        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetBasicQot.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public object parse(ProtoBufPackage pack)
        {
            return Qot_GetBasicQot.Response.ParseFrom(pack.Bodys);
        }


        public void handler(object v)
        {
            Qot_GetBasicQot.Response res = v as Qot_GetBasicQot.Response;
            if (callback != null)
            {
                List<BasicQot> list = new List<BasicQot>();
                foreach (BasicQot qot in res.S2C.BasicQotListList)
                {
                    int market = qot.Security.Market;
                    String symbol = qot.Security.Code;
                    if ((int)this.market == market)
                    {
                        foreach (String innerSymbol in symbols)
                        {
                            if (symbol.Equals(innerSymbol))
                                list.Add(qot);
                        }
                    }
                }
                callback.callback(list);
            }
        }

        public int getnUpdateProtoID()
        {
            return nUpdateProtoID;
        }
        
    }
}
