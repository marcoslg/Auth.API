using Authorize.Application.Users.Queries.Models;
using Authorize.Domain.Users;
using System.Linq;

namespace Authorize.Application.Users.Queries.SearchRole
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
