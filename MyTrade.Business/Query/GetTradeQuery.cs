using MediatR;
using MyTrade.Domain;

namespace MyTrade.Business.Query
{
    public class GetTradeQuery : IRequest<Trade>
    {
        public int Id { get; set; }
    }
}
