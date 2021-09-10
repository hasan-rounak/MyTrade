

using System;
using System.Collections.Generic;

namespace MyTrade.Domain
{
    public class Trade
    {
        public int TradeId { get; set; }
        public string Instrument { get; set; }
        public int Unit { get; set; }
        public double Price { get; set; }
        public double? SellPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime? SellDate { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public KeyValue Status { get; set; }
    }
}
