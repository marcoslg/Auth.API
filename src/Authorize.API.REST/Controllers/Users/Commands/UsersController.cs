using Authorize.API.REST.Bases;
using Authorize.API.REST.Mappers.Commands.Users;
using Authorize.API.REST.Models.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Authorize.API.REST.Controllers.Users.Commands
{
    [Route("api/commands/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : CommandsController
    {
        public UsersController(IMediator mediator)
            : base(mediator)
        {

        }

        [HttpPost]
        public async Task Create(CreateUserRequest commandRequest)
        {
            var command = commandRequest.ToMap();
            await Command(command);
        }
    }
}