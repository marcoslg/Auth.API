using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Roles.Queries.Get.Models
{
    [Authorize(AuthPermisions.RoleGet)]
    public class GetRoleQuery : IRequest<RolePermisionsVM>
    {
        public string Name { get; set; }
    }
}
