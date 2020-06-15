using Authorize.Domain.Roles;
using System.Linq;

namespace Authorize.Application.Features.Roles.Commands.Create
{
    internal static class CreateRoleCommandMapper
    {
        public static Role ToMap(this CreateRoleCommand command)
            => new Role(command.Name, command.Description, command.Permissions.Select(x => new ApplicationRole()
            {
                Application = new Domain.Applications.Application(x.Key),
                Permissions = x.Value.Select(p => Domain.Applications.Permission.For(p)).ToList(),
            }).ToList());
    }
}
