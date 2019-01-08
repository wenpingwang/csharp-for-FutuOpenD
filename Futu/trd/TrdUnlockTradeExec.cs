using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class TrdUnlockTradeExec:IExecutor
    {
        private bool unlock;

        private String pwdMD5;

        private Trd_UnlockTrade.Response response;

        public static int nProtoID = 2005;

        public TrdUnlockTradeExec(bool unlock, String pwdMD5)
        {
            this.unlock = unlock;
            this.pwdMD5 = pwdMD5;
        }

        
    public int getnProtoID()
        {
            return nProtoID;
        }

        
    public ProtoBufPackage buildPackage()
        {
            Trd_UnlockTrade.Request.Builder request = Trd_UnlockTrade.Request.CreateBuilder();
            Trd_UnlockTrade.C2S.Builder c2s = Trd_UnlockTrade.C2S.CreateBuilder();
            c2s.Unlock=unlock;
            if (unlock)
                c2s.PwdMD5=pwdMD5;
            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID=nProtoID;
            pack.Bodys=request.Build().ToByteArray();
            return pack;
        }

        
    public void execute(ProtoBufPackage pack)
        {
            response = Trd_UnlockTrade.Response.ParseFrom(pack.Bodys);
	}

    
    public object getValue()
    {
        return response;
    }

}
}
