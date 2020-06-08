using Authorize.Application.Features.Roles.Queries.Get.Models;
using Authorize.Domain.Roles;
using System.Collections.Generic;
using System.Linq;

namespace Authorize.Application.Features.Roles.Queries.Get
{
    internal static class RoleMapper
    {
        public static RolePermissionsVM ToMap(this Role role)
        {
            var permissions = new Dictionary<string, IEnumerable<string>>();
            foreach (var appPer in role.Applications)
            {
                permissions.Add(appPer.Application.Name, appPer.Permissions.Select(p => p.Name));
            }
            return new RolePermissionsVM(role.Name, role.Description, role.IsEnabled, permissions);
        }


        public static IQueryable<RolePermissionsVM> ToMap(this IQueryable<Role> roleQuery)
            => roleQuery.Select(x => x.ToMap());
    }
}