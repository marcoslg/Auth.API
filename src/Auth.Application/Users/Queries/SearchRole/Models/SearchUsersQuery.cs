using Auth.Application.Attributtes;
using Auth.Application.Users.Queries.Models;
using MediatR;
using System.Collections.Generic;

namespace Auth.Application.Users.Queries.SearchRole.Models
{
    [Authorize(AuthPermisions.UserSearch)]
    public class SearchUsersQuery : IRequest<IEnumerable<UserVM>>
    {
        public string UserName { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
