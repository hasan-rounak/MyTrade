using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MyTrade.Common.DbEntities
{
    public  class TradeData
    {
        public int TradeId { get; set; }
        public string Instrument { get; set; }
        public int Unit { get; set; }
        public double Price { get; set; }
        public double? SellPrice { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime? SellDate { get; set; }
        public IEnumerable<CommentData> Comments { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
   
}
