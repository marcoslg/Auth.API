using Authorize.Application.Attributtes;
using Authorize.Application.Users.Queries.Models;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Users.Queries.SearchRole.Models
{
    [Authorize(AuthPermisions.UserSearch)]
    public class SearchUsersQuery : IRequest<IEnumerable<UserVM>>
    {
        public string UserName { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
