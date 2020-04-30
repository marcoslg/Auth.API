using Auth.Domain.Roles;
using Auth.Domain.Users;
using System.Linq;

namespace Auth.Application.Users.Commands
{
    internal static class CreateUserCommandMapper
    {
        public static User ToMap(this CreateUserCommand command)
            => new User(command.UserName, command.RoleNames?.Select(x => new Role(x)).ToList());
    }
}
