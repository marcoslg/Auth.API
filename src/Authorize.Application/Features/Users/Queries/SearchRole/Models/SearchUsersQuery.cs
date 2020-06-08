using Authorize.Application.Attributtes;
using Authorize.Application.Features.Users.Queries.Models;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Users.Queries.SearchRole.Models
{
    [Authorize(AuthPermissions.UserSearch)]
    public class SearchUsersQuery : IRequest<IEnumerable<UserVM>>
    {
        public string UserName { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
