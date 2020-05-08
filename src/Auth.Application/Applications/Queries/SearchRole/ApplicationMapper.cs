using Auth.Application.Roles.Queries.Models;
using Auth.Domain.Roles;
using System.Linq;

namespace Auth.Application.Applications.Queries.SearchRole
{
    internal static class ApplicationMapper
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
