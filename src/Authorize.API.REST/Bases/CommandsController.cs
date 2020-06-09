using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Authorize.API.REST.Bases
{
    public class CommandsController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public CommandsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Command(IRequest query)
        {
            await _mediator.Send(query);           
        }
    }
}
