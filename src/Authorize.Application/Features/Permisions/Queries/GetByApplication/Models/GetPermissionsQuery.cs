using Authorize.Application.Features.Permisions.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Permisions.Queries.GetByApplication.Models
{
    public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {
        public string ApplicationName { get; set; }
    }
}
