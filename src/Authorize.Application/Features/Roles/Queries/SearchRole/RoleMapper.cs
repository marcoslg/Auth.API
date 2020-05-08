using Authorize.Application.Features.Roles.Queries.Models;
using Authorize.Domain.Roles;
using System.Linq;

namespace Authorize.Application.Features.Roles.Queries.SearchRole
{
    internal static class RoleMapper
    {
        public static RoleVM ToMap(this Role role)
        => new RoleVM(role.Name, role.Description, role.IsEnabled);

        public static IQueryable<RoleVM> ToMap(this IQueryable<Role> roleQuery, int? pageSize, int? page)
        {
            if (pageSize.HasValue && page.HasValue)
            {
                var pageNotNull = page.Value;
                var pageSizeNotNull = pageSize.Value;
                roleQuery = roleQuery.Skip(pageNotNull * pageSizeNotNull).Take(pageSizeNotNull);
            }
            return roleQuery.OrderBy(r => r.Name).Select(x => x.ToMap());
        }
    }
}
