using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Roles.Commands.Delete
{
    [Authorize(AuthPermisions.RoleDisabled)]
    public class DisabledRoleCommand : IRequest
    {
        public string Name { get; set; }
    }
}
