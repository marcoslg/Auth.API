using Authorize.Application.Attributtes;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Roles.Commands.Create
{
    [Authorize(AuthPermissions.RoleCreated)]
    public class CreateRoleCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, IEnumerable<string>> Permissions { get; set; }

        public CreateRoleCommand()
        {
            Permissions = new Dictionary<string, IEnumerable<string>>();
        }
    }
}
