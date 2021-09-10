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
    public class UpdateTradeCommandHandler : IRequestHandler<UpdateTradeCommand, Trade>
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IMapper _mapper;

        public UpdateTradeCommandHandler(ITradeRepository tradeRepository, IMapper mapper)
        {
            this._tradeRepository = tradeRepository;
            this._mapper = mapper;
        }


        public async Task<Trade> Handle(UpdateTradeCommand request, CancellationToken cancellationToken)
        {
            TradeData trade = this._mapper.Map<TradeData>(request);
            TradeData tradeData = await this._tradeRepository.UpdateTrade(trade);
            return this._mapper.Map<Trade>(tradeData);
        }
    }
}
