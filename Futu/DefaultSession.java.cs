using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;
using Trd_GetMaxTrdQtys;

namespace Futu
{
    class DefaultSession : Session, TraderSession
    {
        private Client request;
        private TrdEnv trdenv;
        private List<TrdAcc> trdAccs;

        public void openSession(String ip, int port)
        {

            openSession(ip, port, true);
        }


        public void openSession(String ip, int port, bool keepAlive)
        {
            request = new Client();
            request.KeepAlive = keepAlive;
            request.open(ip, port);
        }

        public GetGlobalState.Response getGlobalState(long futuUserID)
        {
            GetGlobalStateExec exec = new GetGlobalStateExec(futuUserID);
            request.execute(exec);
            return (GetGlobalState.Response)exec.getValue();
        }

        public Qot_GetSubInfo.Response qotGetSubInfo(bool isReqAllConn)
        {
            QotGetSubInfoExec exec = new QotGetSubInfoExec(isReqAllConn);
            request.execute(exec);
            return (Qot_GetSubInfo.Response)exec.getValue();
        }


        public Qot_Sub.Response qotSub(QotMarket market, String[] symbols, SubType[] subTypes)
        {
            QotSubExec exec = new QotSubExec(market, symbols, subTypes, true);
            request.execute(exec);
            return (Qot_Sub.Response)exec.getValue();
        }


        public Qot_Sub.Response qotUnSub(
                QotMarket market, String[] symbols, SubType[] subTypes)
        {
            QotSubExec exec = new QotSubExec(market, symbols, subTypes, false);
            request.execute(exec);
            return (Qot_Sub.Response)exec.getValue();
        }


        public Qot_GetBasicQot.Response stockBasicInfo(QotMarket market, String[] symbol, IUpdateCallBack callback)
        {
            QotGetBasicQotExec exec = new QotGetBasicQotExec(market, symbol, callback);
            request.execute(exec);
            return (Qot_GetBasicQot.Response)exec.getValue();
        }

        //	public QotGetKL.Response qotGetKL(QotMarket market, String symbol, RehabType rehabType, KLType klType, int reqNum, IUpdateCallBack<List<KLine>> callback) 
        //{
        //    QotGetKLExec exec = new QotGetKLExec(market, symbol, rehabType, klType, reqNum, callback);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        //	public QotGetRT.Response qotGetRT(QotMarket market, String symbol, IUpdateCallBack<List<TimeShare>> callback)  
        //{
        //    QotGetRTExec exec = new QotGetRTExec(market, symbol, callback);
        //request.execute(exec);
        //		return exec.getValue();
        //	}


        public Qot_GetTicker.Response qotGetTicker(QotMarket market, String symbol, IUpdateCallBack callback)
        {
            return qotGetTicker(market, symbol, 100, callback);
        }

        public Qot_GetTicker.Response qotGetTicker(QotMarket market, String symbol, int maxRetNum, IUpdateCallBack callback)
        {
            QotGetTickerExec exec = new QotGetTickerExec(market, symbol, maxRetNum, callback);
            request.execute(exec);
            return (Qot_GetTicker.Response)exec.getValue();
        }

        //	public QotGetOrderBook.Response qotGetOrderBook(QotMarket market, String symbol, int num, IUpdateCallBack<OrderBooks> callback) 
        //{
        //    QotGetOrderBookExec exec = new QotGetOrderBookExec(market, symbol, num, callback);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        //	public QotGetBroker.Response qotGetBroker(QotMarket market, String symbol, IUpdateCallBack<Brokers> callback)  
        //{
        //    QotGetBrokerExec exec = new QotGetBrokerExec(market, symbol, callback);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        //	public QotGetHistoryKL.Response qotGetHistoryKL(QotMarket market, String symbol, RehabType rehabType, KLType klType, String beginTime, String endTime, int maxAckKLNum, long needKLFieldsFlag) 
        //{
        //    QotGetHistoryKLExec exec = new QotGetHistoryKLExec(market, symbol, rehabType, klType, beginTime, endTime, maxAckKLNum, needKLFieldsFlag);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        //	public QotGetHistoryKLPoints.Response qotGetHistoryKLPoints(QotMarket market, String[] symbols, RehabType rehabType, KLType klType, String[] timeLists, NoDataMode noDataMode, int maxReqSecurityNum, long needKLFieldsFlag)  
        //{
        //    QotGetHistoryKLPointsExec exec = new QotGetHistoryKLPointsExec(market, symbols, rehabType, klType, timeLists, noDataMode, maxReqSecurityNum, needKLFieldsFlag);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        //	public QotRequestHistoryKL.Response qotRequestHistoryKL(QotMarket market, String symbol, RehabType rehabType, KLType klType, String beginTime, String endTime, int maxAckKLNum, long needKLFieldsFlag, String nextReqKey) 
        //{
        //    QotRequestHistoryKLExec exec = new QotRequestHistoryKLExec(market, symbol, rehabType, klType, beginTime, endTime, maxAckKLNum, needKLFieldsFlag, nextReqKey);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        //	public QotGetRehab.Response qotGetRehab(QotMarket market, String[] symbols)  
        //{
        //    QotGetRehabExec exec = new QotGetRehabExec(market, symbols);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        public Qot_GetStaticInfo.Response qotGetStaticInfo(QotMarket market, SecurityType secType, String[] symbols)
        {
            QotGetStaticInfoExec exec = new QotGetStaticInfoExec(market, symbols, secType);
            request.execute(exec);
            return (Qot_GetStaticInfo.Response)exec.getValue();
        }

        public Qot_GetSecuritySnapshot.Response qotGetSecuritySnapshot(QotMarket market, String[] symbols)
        {
            QotGetSecuritySnapshotExec exec = new QotGetSecuritySnapshotExec(market, symbols);
            request.execute(exec);
            return (Qot_GetSecuritySnapshot.Response)exec.getValue();
        }

        //	public QotGetPlateSet.Response qotGetPlateSet(QotMarket market, PlateSetType plateSetType)   
        //{
        //    QotGetPlateSetExec exec = new QotGetPlateSetExec(market, plateSetType);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        //	public QotGetPlateSecurity.Response qotGetPlateSecurity(QotMarket market, String symbol) 
        //{
        //    QotGetPlateSecurityExec exec = new QotGetPlateSecurityExec(market, symbol);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        //	public QotGetReference.Response qotGetReference(QotMarket market, String symbol, ReferenceType referenceType) 
        //{
        //    QotGetReferenceExec exec = new QotGetReferenceExec(market, symbol, referenceType);
        //request.execute(exec);
        //		return exec.getValue();
        //	}


        public Qot_RegQotPush.Response qotRegQotPush(QotMarket market, String[] symbols, SubType[] subTypes, bool isFirstPush, bool isRegOrUnReg)
        {
            QotRegQotPushExec exec = new QotRegQotPushExec(market, symbols, subTypes, isFirstPush, isRegOrUnReg);
            request.execute(exec);
            return (Qot_RegQotPush.Response)exec.getValue();
        }

        //public Qot_GetTradeDate.Response qotGetTradeDate(QotMarket market, String beginTime, String endTime)
        //{
        //    QotGetTradeDateExec exec = new QotGetTradeDateExec(market, beginTime, endTime);
        //    request.execute(exec);
        //    return exec.getValue();
        //}


        public Qot_RegQotPush.Response qotRegQotPush(QotMarket market, String[] symbols, SubType[] subTypes)
        {
            QotRegQotPushExec exec = new QotRegQotPushExec(market, symbols, subTypes);
            request.execute(exec);
            return (Qot_RegQotPush.Response)exec.getValue();
        }


        //    public QotGetOwnerPlate.Response qotGetOwnerPlate(QotMarket market, String[] symbol) 
        //{
        //    QotGetOwnerPlateExec exec = new QotGetOwnerPlateExec(market, symbol);
        //request.execute(exec);
        //		return exec.getValue();
        //	}


        //    public QotGetHoldingChangeList.Response qotGetHoldingChangeList(QotMarket market, String symbol, int holderCategory, String beginTime, String endTime) 
        //{
        //    QotGetHoldingChangeListExec exec = new QotGetHoldingChangeListExec(market, symbol, holderCategory, beginTime, endTime);
        //request.execute(exec);
        //		return exec.getValue();
        //	}


        //    public QotGetOptionChain.Response qotGetOptionChain(QotMarket market, String symbol, String beginTime, String endTime, int type, int condition) 
        //{
        //    QotGetOptionChainExec exec = new QotGetOptionChainExec(market, symbol, beginTime, endTime, type, condition);
        //request.execute(exec);
        //		return exec.getValue();
        //	}


        //    public QotGetOrderDetail.Response qotGetOrderDetail(QotMarket market, String symbol, IUpdateCallBack<OrderDetails> callback) 
        //{
        //    QotGetOrderDetailExec exec = new QotGetOrderDetailExec(market, symbol, callback);
        //request.execute(exec);
        //		return exec.getValue();
        //	}

        public TraderSession trdUnlockTradeForSimulate(long futuUserID, String pwdMD5)
        {
            this.trdenv = TrdEnv.TrdEnv_Simulate;
            TrdGetAccListExec rrdexec = new TrdGetAccListExec(futuUserID);
            request.execute(rrdexec);
            Trd_GetAccList.Response response = (Trd_GetAccList.Response)rrdexec.getValue();
            if (response.RetType == 0)
            {

                this.trdAccs = response.S2C.AccListList.ToList();

                return this;
            }
            throw new Exception(response.RetMsg);
        }

        public TraderSession trdUnlockTradeForReal(long futuUserID, String pwdMD5)
        {
            this.trdenv = TrdEnv.TrdEnv_Real;
            //获取交易账户列表
            TrdGetAccListExec rrdexec = new TrdGetAccListExec(futuUserID);
            request.execute(rrdexec);
            Trd_GetAccList.Response response = (Trd_GetAccList.Response)rrdexec.getValue();
            if (response.RetType == 0)
            {
                trdAccs = response.S2C.AccListList.ToList();
                //解锁交易
                TrdUnlockTradeExec exec = new TrdUnlockTradeExec(true, pwdMD5);
                request.execute(exec);
                Trd_UnlockTrade.Response res = (Trd_UnlockTrade.Response)exec.getValue();
                if (res.RetType == 0)
                {
                    List<long> accids = new List<long>();
                    foreach (TrdAcc accid in trdAccs)
                    {
                        accids.Add((long)accid.AccID);
                    }
                    //订阅接收交易账户的推送数据
                    TrdSubAccPushExec trdSubAccPushExec = new TrdSubAccPushExec(accids.ToArray());
                    request.execute(trdSubAccPushExec);
                    return this;

                }
                throw new Exception(res.RetMsg);

            }
            throw new Exception(response.RetMsg);
        }

        public Trd_UnlockTrade.Response trdlockTrade()
        {
            TrdUnlockTradeExec exec = new TrdUnlockTradeExec(false, null);
            request.execute(exec);
            return (Trd_UnlockTrade.Response)exec.getValue();
        }

        public Trd_GetFunds.Response trdGetFunds(TrdMarket trdMarket)
        {
            long accID = getAccId(trdenv, trdMarket);
            TrdGetFundsExec exec = new TrdGetFundsExec(trdenv, accID, trdMarket);
            request.execute(exec);
            return (Trd_GetFunds.Response)exec.getValue();
        }


        public Trd_GetPositionList.Response trdGetPositionList(TrdMarket trdMarket, TrdFilterConditions filterConditions, Double filterPLRatioMin, Double filterPLRatioMax)
        {
            //		long accID  = getAccId(trdenv,trdMarket);
            //    TrdGetPositionListExec exec = new TrdGetPositionListExec(trdenv, accID, trdMarket, filterConditions, filterPLRatioMin, filterPLRatioMax);
            //request.execute(exec);
            //return exec.getValue();
            return null;
        }

        public Trd_GetMaxTrdQtys.Response trdGetMaxTrdQtys(TrdMarket trdMarket, OrderType orderType, String code, double price, long orderID, object adjustPrice, object adjustSideAndLimit)
        {
            //		long accID  = getAccId(trdenv,trdMarket);
            //    TrdGetMaxTrdQtysExec exec = new TrdGetMaxTrdQtysExec(trdenv, accID, trdMarket, orderType, code, price, orderID, adjustPrice, adjustSideAndLimit);
            //request.execute(exec);
            //		return exec.getValue();
            return null;
        }

        public Trd_GetOrderList.Response trdGetOrderList(TrdMarket trdMarket, TrdFilterConditions filterConditions, int[] filterStatusList)
        {
            //		long accID  = getAccId(trdenv,trdMarket);
            //    TrdGetOrderListExec exec = new TrdGetOrderListExec(trdenv, accID, trdMarket, filterConditions, filterStatusList);
            //request.execute(exec);
            //		return exec.getValue();
            return null;
        }

        public Trd_GetHistoryOrderList.Response trdGetHistoryOrderList(TrdMarket trdMarket, TrdFilterConditions filterConditions, int[] filterStatusList)
        {
            //		long accID  = getAccId(trdenv,trdMarket);
            //    TrdGetHistoryOrderListExec exec = new TrdGetHistoryOrderListExec(trdenv, accID, trdMarket, filterConditions, filterStatusList);
            //request.execute(exec);
            //		return exec.getValue();
            return null;
        }

        public Trd_PlaceOrder.Response trdPlaceOrder(TrdMarket trdMarket, TrdSide trdSide, OrderType orderType, String code, double qty, double price, Boolean adjustPrice, Double adjustSideAndLimit, IUpdateCallBack callback)
        {
            long accID = getAccId(trdenv, trdMarket);
            TrdPlaceOrderExec exec = new TrdPlaceOrderExec(trdenv, accID, trdMarket, trdSide, orderType, code, qty, price, adjustPrice, adjustSideAndLimit, request.getConnID(), callback);
            request.execute(exec);
            return (Trd_PlaceOrder.Response)exec.getValue();
        }

        public Trd_ModifyOrder.Response trdModifyOrder(TrdMarket trdMarket, long orderID, ModifyOrderOp modifyOrderOp, Boolean forAll, Double qty, Double price, Boolean adjustPrice, Double adjustSideAndLimit)
        {
            //		long accID  = getAccId(trdenv,trdMarket);
            //    TrdModifyOrderExec exec = new TrdModifyOrderExec(trdenv, accID, trdMarket, orderID, modifyOrderOp, forAll, qty, price, adjustPrice, adjustSideAndLimit, request.getConnID());
            //request.execute(exec);
            //		return exec.getValue();
            return null;
        }

        public Trd_GetOrderFillList.Response trdGetOrderFillList(TrdMarket trdMarket, TrdFilterConditions filterConditions, IUpdateCallBack callback)
        {
            long accID = getAccId(trdenv, trdMarket);
            TrdGetOrderFillListExec exec = new TrdGetOrderFillListExec(trdenv, accID, trdMarket, filterConditions, callback);
            request.execute(exec);
            return (Trd_GetOrderFillList.Response)exec.getValue();
        }

        public Trd_GetHistoryOrderFillList.Response trdGetHistoryOrderFillList(TrdMarket trdMarket, TrdFilterConditions filterConditions)
        {
            //		long accID  = getAccId(trdenv,trdMarket);
            //    TrdGetHistoryOrderFillListExec exec = new TrdGetHistoryOrderFillListExec(trdenv, accID, trdMarket, filterConditions);
            //request.execute(exec);
            //		return exec.getValue();
            return null;
        }


        public void close()
        {
            request.close();
        }

        private long getAccId(TrdEnv trdenv, TrdMarket trdMarket)
        {
            long accID = -1;
            foreach (TrdAcc acc in trdAccs)
            {
                if (acc.TrdEnv == (int)trdenv && acc.GetTrdMarketAuthList(0) == (int)trdMarket)
                    accID = (long)acc.AccID;
            }
            if (accID == -1)
                throw new Exception("无该市场交易帐号");
            return accID;
        }

    }
}
