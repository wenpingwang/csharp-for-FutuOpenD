using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotRegQotPushExec : IExecutor
    {
        private Qot_RegQotPush.Response response;

        private QotMarket market;
        private SubType[] subTypes;
        private String[] symbols;
        private bool isRegOrUnReg = true;
        private bool isFirstPush = true;

        public static int nProtoID = 3002;

        public QotRegQotPushExec(QotMarket market, String[] symbols, SubType[] subTypes)
        {
            this.market = market;
            this.subTypes = subTypes;
            this.symbols = symbols;
        }

        public QotRegQotPushExec(QotMarket market, String[] symbols, SubType[] subTypes, bool isFirstPush, bool isRegOrUnReg)
        {
            this.market = market;
            this.subTypes = subTypes;
            this.symbols = symbols;
            this.isFirstPush = isFirstPush;
            this.isRegOrUnReg = isRegOrUnReg;
        }



        public ProtoBufPackage buildPackage()
        {
            Qot_RegQotPush.Request.Builder request = Qot_RegQotPush.Request.CreateBuilder();
            Qot_RegQotPush.C2S.Builder c2s = Qot_RegQotPush.C2S.CreateBuilder();
            foreach (String symbol in symbols)
            {
                Security.Builder security = Security.CreateBuilder();
                security.Market = (int)market;
                security.Code = symbol;
                c2s.AddSecurityList(security);
            }
            foreach (SubType subType in subTypes)
                c2s.AddSubTypeList((int)subType);
            c2s.IsRegOrUnReg = isRegOrUnReg;
            c2s.IsFirstPush = isFirstPush;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_RegQotPush.Response.ParseFrom(pack.Bodys);
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
