using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class TrdSubAccPushExec:IExecutor
    {
        private Trd_SubAccPush.Response response;

        private long[] accIDList;

        public static int nProtoID = 2008;

        public TrdSubAccPushExec(long[] accIDList)
        {
            this.accIDList = accIDList;
        }

        
    public int getnProtoID()
        {
            return nProtoID;
        }

        
    public ProtoBufPackage buildPackage()
        {
            Trd_SubAccPush.Request.Builder request = Trd_SubAccPush.Request.CreateBuilder();
            Trd_SubAccPush.C2S.Builder c2s = Trd_SubAccPush.C2S.CreateBuilder();
            foreach (long accID in accIDList)
                c2s.AddAccIDList((ulong)accID);

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID=nProtoID;
            pack.Bodys=request.Build().ToByteArray();
            return pack;
        }

        
    public void execute(ProtoBufPackage pack)  
        {
            response = Trd_SubAccPush.Response.ParseFrom(pack.Bodys);
	}

    
    public object getValue()
    {
        return response;
    }

}
}
