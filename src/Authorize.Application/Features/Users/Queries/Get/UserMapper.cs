using Authorize.Application.Features.Roles.Queries.Get;
using Authorize.Application.Features.Users.Queries.Get;
using Authorize.Application.Features.Users.Queries.Get.Models;
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
    }
}
