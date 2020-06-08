using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Features.Applications.Commands.Disabled
{
    [Authorize(AuthPermissions.ApplicationDisabled)]
    public class DisabledApplicationCommand : IRequest
    {
        public string Name { get; set; }
    }
}