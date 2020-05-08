using Authorize.Domain.Roles;
using Authorize.Domain.Users;
using System.Linq;

namespace Authorize.Application.Users.Commands.Create
{
    internal static class CreateUserCommandMapper
    {
        public static User ToMap(this CreateUserCommand command)
            => new User(command.UserName, command.RoleNames?.Select(x => new Role(x)).ToList());
    }
}
