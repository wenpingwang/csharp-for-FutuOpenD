using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class QotGetPlateSetExec : IExecutor
    {
        private QotMarket market;

        private PlateSetType plateSetType;

        private Qot_GetPlateSet.Response response;

        public static int nProtoID = 3204;

        public QotGetPlateSetExec(QotMarket market, PlateSetType plateSetType)
        {
            this.market = market;
            this.plateSetType = plateSetType;
        }


        public int getnProtoID()
        {
            return nProtoID;
        }


        public ProtoBufPackage buildPackage()
        {
            Qot_GetPlateSet.Request.Builder request = Qot_GetPlateSet.Request.CreateBuilder();
            Qot_GetPlateSet.C2S.Builder c2s = Qot_GetPlateSet.C2S.CreateBuilder();
            c2s.Market = (int)market;
            c2s.PlateSetType = (int)plateSetType;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID = nProtoID;
            pack.Bodys = request.Build().ToByteArray();
            return pack;
        }


        public void execute(ProtoBufPackage pack)
        {
            response = Qot_GetPlateSet.Response.ParseFrom(pack.Bodys);
        }


        public object getValue()
        {
            return response;
        }
    }
}
