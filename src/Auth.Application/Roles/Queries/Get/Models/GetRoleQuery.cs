using MediatR;

namespace Auth.Application.Roles.Queries.Get.Models
{
    public class GetRoleQuery : IRequest<RoleVM>
    {
        public string Name { get; set; }
    }
}
