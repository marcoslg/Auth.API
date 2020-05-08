using Auth.Application.Applications.Queries.Models;
using Auth.Application.Attributtes;
using MediatR;
using System.Collections.Generic;

namespace Auth.Application.Applications.Queries.SearchRole.Models
{
    [Authorize(AuthPermisions.ApplicationSearch)]
    public class SearchApplicationsQuery : IRequest<IEnumerable<ApplicationVM>>
    {
        public string Name { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}