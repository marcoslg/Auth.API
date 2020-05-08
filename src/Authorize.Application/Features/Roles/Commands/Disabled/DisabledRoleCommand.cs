using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Features.Roles.Commands.Disabled
{
    [Authorize(AuthPermisions.RoleDisabled)]
    public class DisabledRoleCommand : IRequest
    {
        public string Name { get; set; }
    }
}
