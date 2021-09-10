using AutoMapper;
using MediatR;
using MyTrade.Business.Query;
using MyTrade.Common.DbEntities;
using MyTrade.Common.Interfaces;
using MyTrade.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MyTrade.Business.QueryHandler
{
    public class GetTradeQueryHandler : IRequestHandler<GetTradeQuery, Trade>
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IMapper _mapper;

        public GetTradeQueryHandler(ITradeRepository tradeRepository, IMapper mapper)
        {
            this._tradeRepository = tradeRepository;
            this._mapper = mapper;
        }
        public async Task<Trade> Handle(GetTradeQuery request, CancellationToken cancellationToken)
        {
            TradeData trade = await _tradeRepository.GetTrade(request.Id);
            return this._mapper.Map<Trade>(trade);
        }
    }
}
