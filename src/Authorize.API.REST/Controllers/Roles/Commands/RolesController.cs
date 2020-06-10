using Authorize.API.REST.Bases;
using Authorize.API.REST.Mappers.Commands.Applications;
using Authorize.API.REST.Models.Commands.Roles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Authorize.API.REST.Controllers.Roles.Commands
{
    [Route("api/commands/[controller]")]
    [ApiController]    
    [Authorize]
    public class RolesController : CommandsController
    {
        public RolesController(IMediator mediator)
            : base(mediator)
        {

        }

        [HttpPost]
        public async Task Create(CreateRoleRequest commandRequest)
        {
            var command = commandRequest.ToMap();
            await Command(command);
        }
    }
}