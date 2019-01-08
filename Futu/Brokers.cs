using Qot_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    class Brokers
    {
        private List<Broker> brokerAskList;//经纪Ask(卖)盘
        private List<Broker> brokerBidList;//经纪Bid(买)盘

        public List<Broker> BrokerAskList { get => brokerAskList; set => brokerAskList = value; }
        public List<Broker> BrokerBidList { get => brokerBidList; set => brokerBidList = value; }
    }
}
