using System;

namespace MyTrade.Domain
{
    public class Comment
    {
        public int TradeId { get; set; }
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
