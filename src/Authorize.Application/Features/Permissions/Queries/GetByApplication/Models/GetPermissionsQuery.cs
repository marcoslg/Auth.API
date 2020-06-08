using Authorize.Application.Features.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Permissions.Queries.GetByApplication.Models
{
    public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {
        public string ApplicationName { get; set; }
    }
}
