using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Roles.Commands.Enabled
{
    [Authorize(AuthPermisions.RoleEnabled)]
    public class EnabledRoleCommand : IRequest
    {
        public string Name { get; set; }
    }
}
