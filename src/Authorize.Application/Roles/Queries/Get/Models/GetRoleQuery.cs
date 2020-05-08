using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Roles.Queries.Get.Models
{
    [Authorize(AuthPermisions.RoleGet)]
    public class GetRoleQuery : IRequest<RolePermisionsVM>
    {
        public string Name { get; set; }
    }
}
