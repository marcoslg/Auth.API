using Authorize.API.Bases;
using Authorize.Application.Features.Applications.Queries.Get.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Authorize.API.Controllers.Applications.Queries
{
    [ApiController]
    [Route("queries/applications")]
    public class Applications : QueriesController
    {        
        public Applications(IMediator mediator)
            :base(mediator)
        {
            
        }

        [HttpGet]        
        public async Task<ApplicationPermisionsVM> Get(string applicationName)
        {
            var response = await Query(new GetApplicationQuery(applicationName));
            return response;
        }
    }
}
