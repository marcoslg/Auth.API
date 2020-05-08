using Authorize.Application.Permisions.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Permisions.Queries.GetByApplication.Models
{
    public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {   
        public string ApplicationName { get; set; }
    }
}
