using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Applications.Commands.Enabled
{
    [Authorize(AuthPermisions.ApplicationEnabled)]
    public class EnabledApplicationCommand : IRequest
    {
        public string Name { get; set; }
    }
}