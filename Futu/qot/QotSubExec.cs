using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotSubExec : IExecutor
    {
        private Qot_Sub.Response response;

        private QotMarket market;
        private String[] symbols;
        private SubType[] subTypes;
        private bool isSubOrUnSub;

        public static int nProtoID = 3001;

        public QotSubExec(QotMarket market, String[] symbols, SubType[] subTypes, bool isSubOrUnSub)
        {
            this.market = market;
            this.symbols = symbols;
            this.subTypes = subTypes;
            this.isSubOrUnSub = isSubOrUnSub;
        }

        public ProtoBufPackage buildPackage()
        {
            Qot_Sub.Request.Builder request = Qot_Sub.Request.CreateBuilder();
            Qot_Sub.C2S.Builder c2s = Qot_Sub.C2S.CreateBuilder();
            foreach (String symbol in symbols)
                c2s.AddSecurityList(Security.CreateBuilder().SetMarket((int)market).SetCode(symbol));
            c2s.IsSubOrUnSub = isSubOrUnSub;
            foreach (SubType subType in subTypes)
                c2s.AddSubTypeList((int)subType);
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }



        public void execute(ProtoBufPackage pack)
        {
            response = Qot_Sub.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }

    }
}
