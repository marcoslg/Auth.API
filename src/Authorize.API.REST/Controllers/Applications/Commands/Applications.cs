using Authorize.API.REST.Bases;
using Authorize.API.REST.Mappers.Commands.Applications;
using Authorize.API.REST.Models.Commands.Applictions;
using Authorize.API.REST.Modules.Secutiry.ApiKeys.Options;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Authorize.API.REST.Controllers.Applications.Commands
{
    [ApiController]
    [Authorize(AuthenticationSchemes = ApiKeyAuthenticationOptions.DefaultScheme)]
    [Route("api/commands/applications")]
    public class Applications : CommandsController
    {
        public Applications(IMediator mediator)
            : base(mediator)
        {

        }

        [HttpPost("Registry")]
        public async Task Registry(CreateApplicationRequest commandRequest)
        {
            var command = commandRequest.ToMap();
            await Command(command);
        }        
    }
}
