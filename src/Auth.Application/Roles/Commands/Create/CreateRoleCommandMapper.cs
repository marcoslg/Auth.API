using Auth.Domain.Roles;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Application.Roles.Commands.Create
{
    internal static class CreateRoleCommandMapper
    {
        public static Role ToMapRole(this CreateRoleCommand command)
            => new Role(command.Name, command.Description);

        public static IEnumerable<RoleClaim> ToMapRoleClaim(this CreateRoleCommand command)
            => command.Permisions.SelectMany(k => k.Value.Select(v=> new RoleClaim()
            {
                ClaimType ="permission",
                RoleId = command.Name,
                ClaimValue = $"{k.Key}:{k.Value}"
            }));
    }
}
