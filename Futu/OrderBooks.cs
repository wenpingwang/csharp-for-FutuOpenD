using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class OrderBooks
    {
        private List<OrderBook> orderBookBidList;//买盘
        private List<OrderBook> orderBookAskList;//卖盘

        public List<OrderBook> OrderBookBidList { get => orderBookBidList; set => orderBookBidList = value; }
        public List<OrderBook> OrderBookAskList { get => orderBookAskList; set => orderBookAskList = value; }
    }
}
