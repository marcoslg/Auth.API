using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Applications.Commands.Disabled
{
    [Authorize(AuthPermisions.ApplicationDisabled)]
    public class DisabledApplicationCommand : IRequest
    {
        public string Name { get; set; }
    }
}