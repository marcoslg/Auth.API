using Authorize.Application.Features.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Permissions.Queries.GetByUser.Models
{
    public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {
        public string Username { get; set; }
        public string ApplicationName { get; set; }

        public GetPermissionsQuery()
        {

        }

        public GetPermissionsQuery(string username, string appName)
        {
            Username = username;
            ApplicationName = appName;
        }
    }
}
