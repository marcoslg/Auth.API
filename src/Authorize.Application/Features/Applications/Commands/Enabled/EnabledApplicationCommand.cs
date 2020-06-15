using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Features.Applications.Commands.Enabled
{
    [Authorize(AuthPermissions.ApplicationEnabled)]
    public class EnabledApplicationCommand : IRequest
    {
        public string Name { get; set; }
    }
}