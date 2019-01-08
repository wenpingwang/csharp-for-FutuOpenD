using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    interface Session
    {
        void openSession(String ip, int port);

        /**
         * 获取全局状态
         * @param futuUserID
         * @return
         * @
         */
        GetGlobalState.Response getGlobalState(long futuUserID);

        /**
         * 
         * @param ip
         * @param port
         * @param keepAlive ture,提供心跳协议，false不提供。 默认提供. 无心跳协议可以进行功能性测试，不用等待十秒钟关闭程序
         * @throws UnknownHostException
         * @
         */
        void openSession(String ip, int port, bool keepAlive);

        /**
         * 获取股票基本行情
         * @param market
         * @param symbol
         * @return
         * @throws NoSuchAlgorithmException
         * @
         */
        Qot_GetBasicQot.Response stockBasicInfo(QotMarket market, String[] symbol, IUpdateCallBack callback);

        /**
         * 订阅
         * @param market
         * @param symbols
         * @param subType
         * @return
         * @throws NoSuchAlgorithmException
         * @
         */
        Qot_Sub.Response qotSub(QotMarket market, String[] symbols, SubType[] subTypes) ;

        /**
         * 反订阅
         * @param market
         * @param symbols
         * @param subType
         * @return
         * @throws NoSuchAlgorithmException
         * @
         */
        Qot_Sub.Response qotUnSub(QotMarket market, String[] symbols, SubType[] subTypes) ;

        /**
         * 获取订阅信息
         * @param isReqAllConn 是否返回所有连接的订阅状态,false只返回当前连接数据
         * @return
         * @
         */
        Qot_GetSubInfo.Response qotGetSubInfo(bool isReqAllConn) ;

        /**
         * 获取K线
         * @param market
         * @param symbol
         * @param rehabType
         * @param klType
         * @param reqNum
         * @return
         * @
         */
        //QotGetKL.Response qotGetKL(QotMarket market, String symbol, RehabType rehabType, KLType klType, int reqNum, IUpdateCallBack<List<KLine>> callback) ;

        /**
         * 分时
         * @param market
         * @param symbol
         * @param callback
         * @return
         * @
         */
        //QotGetRT.Response qotGetRT(QotMarket market, String symbol, IUpdateCallBack<List<TimeShare>> callback)  ;

        /**
         * 逐笔 maxRetNum 100
         * @param market
         * @param symbol
         * @param 
         * @return
         * @
         */
        Qot_GetTicker.Response qotGetTicker(QotMarket market, String symbol, IUpdateCallBack callback) ;

        /**
         * 逐笔
         * @param market
         * @param symbol
         * @param maxRetNum
         * @return
         * @
         */
        Qot_GetTicker.Response qotGetTicker(QotMarket market, String symbol, int maxRetNum, IUpdateCallBack callback) ;

        /**
         * 买卖盘
         * @param market
         * @param symbol
         * @param num
         * @param callback
         * @return
         * @
         */
        //QotGetOrderBook.Response qotGetOrderBook(QotMarket market, String symbol, int num, IUpdateCallBack<OrderBooks> callback) ;

        /**
         * 经纪队列
         * @param market
         * @param symbol
         * @param callback
         * @return
         * @
         */
        //QotGetBroker.Response qotGetBroker(QotMarket market, String symbol, IUpdateCallBack<Brokers> callback)  ;

        /**
         * 单只股票一段历史K线(必须先下载本地历史数据)
         * 从1.08开始富途不再提供本地历史数据全量下载。请调用qotRequestHistoryKL
         * @param market
         * @param symbol
         * @param rehabType
         * @param klType
         * @param beginTime
         * @param endTime
         * @param maxAckKLNum <0 所有数据
         * @param needKLFieldsFlag <0 所有字段
         * @return
         * @
         */
        //QotGetHistoryKL.Response qotGetHistoryKL(QotMarket market, String symbol, RehabType rehabType, KLType klType, String beginTime, String endTime, int maxAckKLNum, long needKLFieldsFlag) ;

        /**
         * 获取多只股票多点历史K线(必须先下载本地历史数据)
         * 从1.08开始富途不再提供本地历史数据全量下载。请调用qotRequestHistoryKL
         * @param market
         * @param symbols
         * @param rehabType
         * @param klType
         * @param timeLists 最多5个时间点
         * @param noDataMode
         * @param maxReqSecurityNum <0 所有数据
         * @param needKLFieldsFlag <0 所有字段
         * @return
         * @
         */
        //QotGetHistoryKLPoints.Response qotGetHistoryKLPoints(QotMarket market, String[] symbols, RehabType rehabType, KLType klType, String[] timeLists, NoDataMode noDataMode, int maxReqSecurityNum, long needKLFieldsFlag) ;

        /**
         * 单只股票一段历史K线(1.08新接口，不再提供本地历史数据全量下载，不要本地数据直接调用)
         * @param market
         * @param symbol
         * @param rehabType
         * @param klType
         * @param beginTime
         * @param endTime
         * @param maxAckKLNum <0 所有数据
         * @param needKLFieldsFlag <0 所有字段
         * @param nextReqKey  分页请求的key。如果start和end之间的数据点多于max_count，那么后续请求时，要传入上次调用返回的page_req_key。初始请求时应该传None。
         * @return
         * @
         */
        //QotRequestHistoryKL.Response qotRequestHistoryKL(QotMarket market, String symbol, RehabType rehabType, KLType klType, String beginTime, String endTime, int maxAckKLNum, long needKLFieldsFlag, String nextReqKey) ;

        /**
         * 注册行情推送
         * @param market
         * @param symbols
         * @param subTypes
         * @return
         * @
         */
        Qot_RegQotPush.Response qotRegQotPush(QotMarket market, String[] symbols, SubType[] subTypes) ;

        /**
         * 获取复权信息
         * @param market
         * @param symbols
         * @return
         * @
         */
        //QotGetRehab.Response qotGetRehab(QotMarket market, String[] symbols)  ;

        /**
         * 获取某一市场的证券信息
         * 如香港所有股票: QotMarket.QotMarket_HK_Security, SecurityType.SecurityType_Eqty,null
         * @param market
         * @param symbols
         * @param secType
         * @return
         * @
         */
        Qot_GetStaticInfo.Response qotGetStaticInfo(QotMarket market, SecurityType secType, String[] symbols);

        /**
         * 获取股票快照
         * @param market
         * @param symbols
         * @return
         * @
         */
        Qot_GetSecuritySnapshot.Response qotGetSecuritySnapshot(QotMarket market, String[] symbols);

        /**
         * 获取板块集合下的板块
         * @param market
         * @param plateSetType
         * @return
         * @
         */
        //QotGetPlateSet.Response qotGetPlateSet(QotMarket market, PlateSetType plateSetType)   ;

        /**
         * 获取板块下的股票
         * @param market
         * @param symbol
         * @return
         * @
         */
        //QotGetPlateSecurity.Response qotGetPlateSecurity(QotMarket market, String symbol) ;

        /**
         * 获取正股相关股票
         * @param market
         * @param symbol
         * @param referenceType
         * @return
         * @
         */
        //QotGetReference.Response qotGetReference(QotMarket market, String symbol, ReferenceType referenceType) ;
        /**
         * 注册行情推送
         * @param market
         * @param symbols
         * @param subTypes
         * @param isFirstPush
         * @param isRegOrUnReg
         * @return
         * @
         */
        Qot_RegQotPush.Response qotRegQotPush(QotMarket market, String[] symbols, SubType[] subTypes, bool isFirstPush, bool isRegOrUnReg) ;

        /**
         * 获取市场交易日
         * @param market
         * @param beginTime
         * @param endTime
         * @return
         * @
         */
        //QotGetTradeDate.Response qotGetTradeDate(QotMarket market, String beginTime, String endTime) ;

        /**
         * 获取股票所属板块
         * @param market
         * @param symbol
         * @return
         * @
         */
        //QotGetOwnerPlate.Response qotGetOwnerPlate(QotMarket market, String[] symbol) ;

        /**
         * 获取持股变化列表(目前仅支持美股 1.08)
         * @param market
         * @param symbol
         * @param beginTime //开始时间，严格按YYYY-MM-DD HH:MM:SS或YYYY-MM-DD HH:MM:SS.MS格式传
         * @param endTime //结束时间，严格按YYYY-MM-DD HH:MM:SS或YYYY-MM-DD HH:MM:SS.MS格式传
         * @return
         * @
         */
        //QotGetHoldingChangeList.Response qotGetHoldingChangeList(QotMarket market, String symbol, int holderCategory, String beginTime, String endTime) ;

        /**
         * 获取期权链(目前仅支持美股 1.08)
         * @param market
         * @param symbol
         * @param beginTime //期权到期日开始时间
         * @param endTime //期权到期日结束时间,时间跨度最多一个月
         * @param type
         * @param condition
         * @return
         * @
         */
        //QotGetOptionChain.Response qotGetOptionChain(QotMarket market, String symbol, String beginTime, String endTime, int type, int condition) ;

        /**
         * 获取委托明细(至1.08应该只支持A股level2行情)
         * @param market
         * @param symbol
         * @return
         * @
         */
        //QotGetOrderDetail.Response qotGetOrderDetail(QotMarket market, String symbol, IUpdateCallBack<OrderDetails> callback) ;

        /**
         * 解锁模拟盘交易
         * @return
         * @
         */
        TraderSession trdUnlockTradeForSimulate(long futuUserID, String pwdMD5);
        /**
         * 解锁实盘盘交易
         * @param futuUserID
         * @param pwdMD5
         * @return
         * @
         */
        TraderSession trdUnlockTradeForReal(long futuUserID, String pwdMD5);

        void close();

    }
}
