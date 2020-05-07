using Auth.Application.Attributtes;
using Auth.Application.Roles.Queries.Models;
using MediatR;
using System.Collections.Generic;

namespace Auth.Application.Roles.Queries.SearchRole.Models
{
    [Authorize(AuthPermisions.RoleSearch)]
    public class SearchRolesQuery : IRequest<IEnumerable<RoleVM>>
    {
        public string Name { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
