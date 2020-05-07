using Auth.Application.Roles.Queries.Get.Models;
using Auth.Application.Roles.Queries.Models;
using Auth.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Application.Roles.Queries.Get
{
    internal static class RoleMapper
    {
        public static RolePermisionsVM ToMap(this Role role)
        {
            var permisions = new Dictionary<string, IEnumerable<string>>();
            foreach(var appPer in role.Applications)
            {
                permisions.Add(appPer.Application.Name, appPer.Permisions.Select(p => p.Name));
            }
            return new RolePermisionsVM(role.Name, role.Description, role.IsEnabled, permisions);
        }
        

        public static IQueryable<RolePermisionsVM> ToMap(this IQueryable<Role> roleQuery)
       => roleQuery.Select(x => x.ToMap());
    }
}
