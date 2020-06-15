using Authorize.Application.Features.Roles.Queries.Models;
using Authorize.Application.Features.Users.Queries.Get.Models;
using Authorize.Domain.Relations;
using Authorize.Domain.Users;
using System.Linq;

namespace Authorize.Application.Features.Users.Queries.Get
{
    internal static class UserMapper
    {
        public static UserWithRolesVM ToMap(this User user)
        {
            return new UserWithRolesVM(user.UserName, user.IsEnabled, user.Roles.Select(r => r.ToMap()).ToList());
        }


        public static IQueryable<UserWithRolesVM> ToMap(this IQueryable<User> roleQuery)
       => roleQuery.Select(x => x.ToMap());


        public static RoleVM ToMap(this UserRole userRole)
       => new RoleVM(userRole.Role.Name, userRole.Role.Description, userRole.Role.IsEnabled);
    }
}
