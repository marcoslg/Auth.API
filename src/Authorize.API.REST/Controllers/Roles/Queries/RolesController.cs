using Authorize.API.REST.Bases;
using Authorize.Application.Features.Applications.Queries.Get.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Authorize.API.REST.Controllers.Roles.Queries
{
    [ApiController]
    [Authorize]
    [Route("api/queries/roles")]
    public class RolesController : QueriesController
    {
        public RolesController(IMediator mediator)
            : base(mediator)
        {

        }

        [HttpGet("{applicationName}")]
        public async Task<ApplicationPermissionsVM> Get(string applicationName)
        {
            var response = await Query(new GetApplicationQuery(applicationName));
            return response;
        }
    }
}