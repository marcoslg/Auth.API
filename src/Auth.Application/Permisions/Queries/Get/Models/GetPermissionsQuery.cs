using MediatR;
using System.Collections.Generic;

namespace Auth.Application.Permisions.Queries.Get
{
    public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {
        public string Username { get; set; }
        public string ApplicationName { get; set; }
    }
}
