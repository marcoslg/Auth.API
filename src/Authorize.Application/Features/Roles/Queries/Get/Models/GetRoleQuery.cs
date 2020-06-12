using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Features.Roles.Queries.Get.Models
{
    [Authorize(AuthPermissions.RoleGet)]
    public class GetRoleQuery : IRequest<RolePermissionsVM>
    {
        public string Name { get; set; }

        public GetRoleQuery()
        {

        }
        public GetRoleQuery(string roleName)
        {
            Name = roleName;
        }
    }
}
