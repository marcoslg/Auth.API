using Authorize.Application.Attributtes;
using Authorize.Application.Features.Applications.Queries.Models;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Applications.Queries.SearchRole.Models
{
    [Authorize(AuthPermissions.ApplicationSearch)]
    public class SearchApplicationsQuery : IRequest<IEnumerable<ApplicationVM>>
    {
        public string Name { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}