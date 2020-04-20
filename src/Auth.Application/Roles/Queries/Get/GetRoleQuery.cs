using MediatR;

namespace Auth.Application.Roles.Queries.Get
{
    public class GetRoleQuery : IRequest<RoleVM>
    {
        public string Name { get; set; }
    }
}
