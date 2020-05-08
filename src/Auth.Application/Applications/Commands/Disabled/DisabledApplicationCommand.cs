using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Applications.Commands.Delete
{
    [Authorize(AuthPermisions.RoleDisabled)]
    public class DisabledApplicationCommand : IRequest
    {
        public string Name { get; set; }
    }
}