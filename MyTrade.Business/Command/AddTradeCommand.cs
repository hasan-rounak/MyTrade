using MediatR;
using MyTrade.Domain;

namespace MyTrade.Business.Command
{
    public class AddTradeCommand : Trade, IRequest<Trade>
    {
    }
}
