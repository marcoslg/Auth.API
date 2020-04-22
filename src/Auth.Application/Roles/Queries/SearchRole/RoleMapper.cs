using Auth.Application.Roles.Queries.SearchRole.Models;
using Auth.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Application.Roles.Queries.SearchRole
{
    internal static class RoleMapper
    {
        public static RoleVM ToMap(this Role role)
        => new RoleVM(role.Name, role.Description);

        public static IQueryable<RoleVM> ToMap(this IQueryable<Role> roleQuery)
       => roleQuery.Select(x => x.ToMap());
    }
}
