using Authorize.API.REST.Models.Commands.Users;
using Authorize.Application.Features.Users.Commands.Create;

namespace Authorize.API.REST.Mappers.Commands.Users
{
    internal static class CreateUserRequestMapper
    {
        public static CreateUserCommand ToMap(this CreateUserRequest request)
            => new CreateUserCommand()
            { 
                UserName = request.UserName,
                RoleNames = request.RoleNames
            };
    }
}
