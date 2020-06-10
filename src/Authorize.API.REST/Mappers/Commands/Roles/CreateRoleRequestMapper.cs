using Authorize.API.REST.Models.Commands.Roles;
using Authorize.Application.Features.Roles.Commands.Create;

namespace Authorize.API.REST.Mappers.Commands.Applications
{
    internal static class CreateRoleRequestMapper
    {
        public static CreateRoleCommand ToMap(this CreateRoleRequest request)
            => new CreateRoleCommand(request.Name, request.Description, request.Permissions);
    }
}
