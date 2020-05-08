using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Applications.Commands.Disabled
{
    [Authorize(AuthPermisions.ApplicationDisabled)]
    public class DisabledApplicationCommand : IRequest
    {
        public string Name { get; set; }
    }
}