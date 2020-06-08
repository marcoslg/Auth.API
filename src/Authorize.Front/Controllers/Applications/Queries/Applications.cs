using Authorize.Application.Features.Applications.Queries.Get.Models;
using Authorize.Application.Features.Applications.Queries.Models;
using Authorize.Application.Features.Applications.Queries.SearchRole.Models;
using Authorize.Front.Bases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authorize.Front.Controllers.Applications.Queries
{
    [ApiController]
    [Route("api/queries/applications")]
    public class Applications : QueriesController
    {
        public Applications(IMediator mediator)
            : base(mediator)
        {

        }

        [HttpGet("{applicationName}")]
        public async Task<ApplicationPermissionsVM> Get(string applicationName)
        {
            var response = await Query(new GetApplicationQuery(applicationName));
            return response;
        }
        [HttpGet("Search/{applicationName}")]
        public async Task<IEnumerable<ApplicationVM>> SearchApplication(string applicationName, int? page, int? pageSize)
        {
            var response = await Query(new SearchApplicationsQuery()
            {
                Name = applicationName,
                Page = page,
                PageSize = pageSize

            });
            return response;
        }
    }
}
