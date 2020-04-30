using Auth.Application.Permisions.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Auth.Application.Permisions.Queries.GetByApplication.Models
{
    public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {   
        public string ApplicationName { get; set; }
    }
}
