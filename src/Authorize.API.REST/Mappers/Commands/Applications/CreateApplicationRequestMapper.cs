using Authorize.API.REST.Models.Commands.Applictions;
using Authorize.Application.Features.Applications.Commands.Create;
using System.Linq;

namespace Authorize.API.REST.Mappers.Commands.Applications
{
    internal static class CreateApplicationRequestMapper
    {
        public static CreateApplicationCommand ToMap(this CreateApplicationRequest request)
            => new CreateApplicationCommand(request.Name, request.Description, request.Permissions?.ToList());
    }
}
