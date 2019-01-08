using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;

namespace Futu
{
    class TrdGetOrderFillListExec :IExecutor
    {
        private TrdEnv trdenv;
        private long accID;
        private TrdMarket trdMarket;

        private TrdFilterConditions filterConditions;

        private Trd_GetOrderFillList.Response response;

        private IUpdateCallBack callback;

        public static int nProtoID = 2211;

        public static int nUpdateProtoID = 2218;


        public TrdGetOrderFillListExec(TrdEnv trdenv, long accID, TrdMarket trdMarket, TrdFilterConditions filterConditions, IUpdateCallBack callback)
        {
            this.trdenv = trdenv;
            this.accID = accID;
            this.trdMarket = trdMarket;
            this.filterConditions = filterConditions;
            this.callback = callback;
        }
        
    public int getnProtoID()
        {
            return nProtoID;
        }
        
    public ProtoBufPackage buildPackage()
        {
            Trd_GetOrderFillList.Request.Builder request = Trd_GetOrderFillList.Request.CreateBuilder();
            Trd_GetOrderFillList.C2S.Builder c2s = Trd_GetOrderFillList.C2S.CreateBuilder();
            TrdHeader.Builder headerBuilder = TrdHeader.CreateBuilder();
            headerBuilder.TrdEnv=(int)trdenv;
            headerBuilder.AccID=(ulong)accID;
            headerBuilder.TrdMarket=(int)trdMarket;
            c2s.Header=headerBuilder.Build();
            if (filterConditions != null)
                c2s.FilterConditions=filterConditions;

            request.SetC2S(c2s);
            ProtoBufPackage pack = new ProtoBufPackage();
            pack.NProtoID=nProtoID;
            pack.Bodys=request.Build().ToByteArray();
            return pack;
        }
        
    public void execute(ProtoBufPackage pack)
        {
            response = Trd_GetOrderFillList.Response.ParseFrom(pack.Bodys);
	}
    
    public object getValue()
    {
        return response;
    }
    
    public Trd_UpdateOrderFill.Response parse(ProtoBufPackage pack) 
    {
		return Trd_UpdateOrderFill.Response.ParseFrom(pack.Bodys);
    }
    
    public void handler(Trd_UpdateOrderFill.Response res)
    {
        if (callback != null)
        {
            callback.callback(res);
        }
    }
        
    public int getnUpdateProtoID()
    {
        return nUpdateProtoID;
    }
}
}
