using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyTrade.API.Controllers
{
    public class ApiControllerBase: ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            this._mediator = mediator;
        }

        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await this._mediator.Send(command);
        }

        protected async Task<ActionResult<TResult>> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await this._mediator.Send(query);
        }
    }
}
