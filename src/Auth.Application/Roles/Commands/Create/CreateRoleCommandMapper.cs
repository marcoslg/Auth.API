using Auth.Domain.Roles;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Application.Roles.Commands.Create
{
    internal static class CreateRoleCommandMapper
    {
        public static Role ToMap(this CreateRoleCommand command)
            => new Role(command.Name, command.Description, command.Permisions.Select(x => new ApplicationRole()
            {
                Application = new Domain.Applications.Application() { Name = x.Key },
                Permisions = x.Value.Select(p => new Domain.Applications.Permision() { Name = p })
            }));
    }
}
