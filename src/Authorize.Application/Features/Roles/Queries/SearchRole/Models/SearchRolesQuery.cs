using Authorize.Application.Attributtes;
using Authorize.Application.Features.Roles.Queries.Models;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Roles.Queries.SearchRole.Models
{
    [Authorize(AuthPermissions.RoleSearch)]
    public class SearchRolesQuery : IRequest<IEnumerable<RoleVM>>
    {
        public string Name { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
