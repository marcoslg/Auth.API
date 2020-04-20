using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Application.Roles.Queries.SearchRole
{
    public class SearchRolesQuery : IRequest<IEnumerable<RoleVM>>
    {
        public string Name { get; set; }
    }
}
