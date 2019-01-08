using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trd_Common;

namespace Futu
{
    interface TraderSession
    {
        /**
	 * 获取账户资金
	 * @param trdenv
	 * @param trdMarket
	 * @return
	 * @
	 */
        Trd_GetFunds.Response trdGetFunds(TrdMarket trdMarket) ;

        /**
         * 获取持仓列表
         * @param trdenv
         * @param trdMarket
         * @param filterConditions
         * @param filterPLRatioMin
         * @param filterPLRatioMax
         * @return
         * @
         */
        Trd_GetPositionList.Response trdGetPositionList(TrdMarket trdMarket, TrdFilterConditions filterConditions, Double filterPLRatioMin, Double filterPLRatioMax) ;

        /**
         * 获取最大交易数量,模拟盘不支持
         * @param trdenv
         * @param trdMarket
         * @param orderType
         * @param code
         * @param price
         * @param orderID
         * @param adjustPrice
         * @param adjustSideAndLimit
         * @return
         * @
         */
        Trd_GetMaxTrdQtys.Response trdGetMaxTrdQtys(TrdMarket trdMarket, OrderType orderType, String code, double price, long orderID, object adjustPrice, object adjustSideAndLimit) ;

        /**
         * 获取订单列表
         * @param trdMarket
         * @param filterConditions
         * @param filterStatusList
         * @return
         * @
         */
        Trd_GetOrderList.Response trdGetOrderList(TrdMarket trdMarket, TrdFilterConditions filterConditions, int[] filterStatusList) ;

        /**
         * 获取历史订单列表
         * @param trdMarket
         * @param filterConditions
         * @param filterStatusList
         * @return
         * @
         */
        Trd_GetHistoryOrderList.Response trdGetHistoryOrderList(TrdMarket trdMarket, TrdFilterConditions filterConditions, int[] filterStatusList) ;

        /**
         * 下单(含推送订单更新)
         * @param trdMarket
         * @param trdSide
         * @param orderType
         * @param code
         * @param qty
         * @param price
         * @param adjustPrice
         * @param adjustSideAndLimit
         * @param callback
         * @return
         * @
         */
        Trd_PlaceOrder.Response trdPlaceOrder(TrdMarket trdMarket, TrdSide trdSide, OrderType orderType, String code, double qty, double price, Boolean adjustPrice, Double adjustSideAndLimit, IUpdateCallBack callback) ;

        /**
         * 修改订单(改价、改量、改状态等)
         * @param trdMarket
         * @param orderID
         * @param modifyOrderOp
         * @param forAll
         * @param qty
         * @param price
         * @param adjustPrice
         * @param adjustSideAndLimit
         * @return
         * @
         */
        Trd_ModifyOrder.Response trdModifyOrder(TrdMarket trdMarket, long orderID, ModifyOrderOp modifyOrderOp, Boolean forAll, Double qty, Double price, Boolean adjustPrice, Double adjustSideAndLimit) ;

        /**
         * 获取成交列表
         * @param trdMarket
         * @param filterConditions
         * @return
         * @
         */
        Trd_GetOrderFillList.Response trdGetOrderFillList(TrdMarket trdMarket, TrdFilterConditions filterConditions, IUpdateCallBack callback) ;

        /**
         * 获取历史成交列表
         * @param trdMarket
         * @param filterConditions
         * @return
         * @
         */
        Trd_GetHistoryOrderFillList.Response trdGetHistoryOrderFillList(TrdMarket trdMarket, TrdFilterConditions filterConditions) ;

        /**
         * 锁定交易
         * @return
         * @
         */
        Trd_UnlockTrade.Response trdlockTrade() ;
    }
}
