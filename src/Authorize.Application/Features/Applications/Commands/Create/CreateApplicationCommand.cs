using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Features.Applications.Commands.Create
{
    [Authorize(AuthPermissions.ApplicationCreated)]
    public class CreateApplicationCommand : IRequest<string>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
