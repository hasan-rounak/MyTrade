using MediatR;
using MyTrade.Domain;

namespace MyTrade.Business.Command
{
    public class UpdateTradeCommand : Trade, IRequest<Trade>
    {
    }
}
