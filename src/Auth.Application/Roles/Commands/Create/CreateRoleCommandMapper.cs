using Auth.Domain.Roles;
using System.Linq;

namespace Auth.Application.Roles.Commands.Create
{
    internal static class CreateRoleCommandMapper
    {
        public static Role ToMap(this CreateRoleCommand command)
            => new Role(command.Name, command.Description, command.Permisions.Select(x => new ApplicationRole()
            {
                Application = new Domain.Applications.Application(x.Key),
                Permisions = x.Value.Select(p => Domain.Applications.Permision.For(p)).ToList(),
            }).ToList());
    }
}
