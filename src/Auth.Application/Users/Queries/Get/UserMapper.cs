using Auth.Application.Roles.Queries.Get;
using Auth.Application.Users.Queries.Get;
using Auth.Application.Users.Queries.Get.Models;
using Auth.Domain.Users;
using System.Linq;

namespace Auth.Application.Users.Queries.Get
{
    internal static class UserMapper
    {
        public static UserWithRolesVM ToMap(this User user)
        {            
            return new UserWithRolesVM(user.UserName, user.IsEnabled, user.Roles.Select(r=> r.ToMap()).ToList());
        }


        public static IQueryable<UserWithRolesVM> ToMap(this IQueryable<User> roleQuery)
       => roleQuery.Select(x => x.ToMap());
    }
}
