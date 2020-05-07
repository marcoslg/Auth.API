using Auth.Application.Users.Queries.Models;
using Auth.Domain.Users;
using System.Linq;

namespace Auth.Application.Users.Queries.SearchRole
{
    internal static class UserMapper
    {
        public static UserVM ToMap(this User user)
        => new UserVM(user.UserName, user.IsEnabled);

        public static IQueryable<UserVM> ToMap(this IQueryable<User> userQuery, int? pageSize, int? page)
        {
            if (pageSize.HasValue && page.HasValue)
            {
                var pageNotNull = page.Value;
                var pageSizeNotNull = pageSize.Value;
                userQuery = userQuery.Skip(pageNotNull * pageSizeNotNull).Take(pageSizeNotNull);
            }
            return userQuery.OrderBy(r => r.UserName).Select(x => x.ToMap());
        }
    }
}
