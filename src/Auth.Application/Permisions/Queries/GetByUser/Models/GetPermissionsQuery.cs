using Auth.Application.Permisions.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Auth.Application.Permisions.Queries.GetByUser.Models
{
    public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {
        public string Username { get; set; }
        public string ApplicationName { get; set; }
    }
}
