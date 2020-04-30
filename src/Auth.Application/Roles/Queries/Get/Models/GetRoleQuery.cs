using Auth.Application.Roles.Queries.Models;
using MediatR;

namespace Auth.Application.Roles.Queries.Get.Models
{
    public class GetRoleQuery : IRequest<RolePermisionsVM>
    {
        public string Name { get; set; }
    }
}
