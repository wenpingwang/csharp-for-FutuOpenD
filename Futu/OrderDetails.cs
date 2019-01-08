using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class OrderDetails
    {
        private OrderDetail OrderDetailBid;//买盘
        private OrderDetail OrderDetailAsk;//卖盘

        public OrderDetail OrderDetailBid1 { get => OrderDetailBid; set => OrderDetailBid = value; }
        public OrderDetail OrderDetailAsk1 { get => OrderDetailAsk; set => OrderDetailAsk = value; }
    }
}
