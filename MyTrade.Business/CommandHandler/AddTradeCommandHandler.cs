using AutoMapper;
using MediatR;
using MyTrade.Business.Command;
using MyTrade.Common.DbEntities;
using MyTrade.Common.Interfaces;
using MyTrade.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MyTrade.Business.CommandHandler
{

    public class AddTradeCommandHandler : IRequestHandler<AddTradeCommand, Trade>
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IMapper _mapper;

        public AddTradeCommandHandler(ITradeRepository tradeRepository, IMapper mapper)
        {
            this._tradeRepository = tradeRepository;
            this._mapper = mapper;
        }
        public async Task<Trade> Handle(AddTradeCommand request, CancellationToken cancellationToken)
        {
            TradeData trade = this._mapper.Map<TradeData>(request);
            TradeData tradeData = await this._tradeRepository.AddTrade(trade);
            return this._mapper.Map<Trade>(tradeData);
        }
    }
}
