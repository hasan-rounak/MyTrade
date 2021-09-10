using MediatR;
using MyTrade.Domain;
using System.Collections.Generic;

namespace MyTrade.Business.Query
{
    public class GetAllTradesQuery : IRequest<IEnumerable<Trade>>
    {
        public string Status { get; set; }
    }
}
