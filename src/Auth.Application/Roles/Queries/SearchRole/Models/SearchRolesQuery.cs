using Auth.Application.Roles.Queries.Models;
using MediatR;
using System.Collections.Generic;

namespace Auth.Application.Roles.Queries.SearchRole.Models
{
    public class SearchRolesQuery : IRequest<IEnumerable<RoleVM>>
    {
        public string Name { get; set; }
    }
}
