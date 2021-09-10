using AutoMapper;
using MediatR;
using MyTrade.Business.Query;
using MyTrade.Common.DbEntities;
using MyTrade.Common.Interfaces;
using MyTrade.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyTrade.Business.QueryHandler
{

    public class GetAllTradesQueryHandler : IRequestHandler<GetAllTradesQuery, IEnumerable<Trade>>
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IMapper _mapper;

        public GetAllTradesQueryHandler(ITradeRepository tradeRepository, IMapper mapper)
        {
            this._tradeRepository = tradeRepository;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<Trade>> Handle(GetAllTradesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TradeData> trades = await _tradeRepository.GetAllTrades(request.Status);
            return this._mapper.Map<IEnumerable<Trade>>(trades);
        }
    }
}
