using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTrade.Business.Command;
using MyTrade.Business.Query;
using MyTrade.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrade.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1")]
    public class TradeController : ApiControllerBase
    {
        private readonly ILogger<TradeController> _logger;

        public TradeController(IMediator mediator, ILogger<TradeController> logger) : base(mediator)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Returns all Trades.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("trades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Trade>>> GetAllDeals([FromQuery] GetAllTradesQuery query)
        {
            return await this.QueryAsync(query);
        }

        /// <summary>
        /// Get Details of a specific trade
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("trade/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Trade>> GetDeal([FromRoute] GetTradeQuery query)
        {
            return await this.QueryAsync(query);
        }

        /// <summary>
        /// Add a new trade
        /// </summary>
        /// <param name="newTrade"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Trade>> AddTrade([FromBody] AddTradeCommand newTrade)
        {         
            return await this.CommandAsync(newTrade);
            //return this.CreatedAtAction(nameof(this.GetDeal), new { trade.TradeId }, trade);
        }

        /// <summary>
        /// Update existing trade
        /// </summary>
        /// <param name="id"></param>

        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Trade>> UpdateIndividual([FromRoute] string id, [FromBody] UpdateTradeCommand trade)
        {
            return await this.CommandAsync(trade);
        }
    }
}
