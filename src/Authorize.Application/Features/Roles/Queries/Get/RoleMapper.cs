using Authorize.Application.Features.Roles.Queries.Get.Models;
using Authorize.Domain.Roles;
using System.Collections.Generic;
using System.Linq;

namespace Authorize.Application.Features.Roles.Queries.Get
{
    internal static class RoleMapper
    {
        public static RolePermisionsVM ToMap(this Role role)
        {
            var permisions = new Dictionary<string, IEnumerable<string>>();
            foreach (var appPer in role.Applications)
            {
                permisions.Add(appPer.Application.Name, appPer.Permisions.Select(p => p.Name));
            }
            return new RolePermisionsVM(role.Name, role.Description, role.IsEnabled, permisions);
        }


        public static IQueryable<RolePermisionsVM> ToMap(this IQueryable<Role> roleQuery)
            => roleQuery.Select(x => x.ToMap());
    }
}