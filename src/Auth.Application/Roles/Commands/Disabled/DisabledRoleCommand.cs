using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Roles.Commands.Disabled
{
    [Authorize(AuthPermisions.RoleDisabled)]
    public class DisabledRoleCommand : IRequest
    {
        public string Name { get; set; }
    }
}
