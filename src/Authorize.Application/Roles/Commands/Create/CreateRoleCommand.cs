using Authorize.Application.Attributtes;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Roles.Commands.Create
{
    [Authorize(AuthPermisions.RoleCreated)]
    public class CreateRoleCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, IEnumerable<string>> Permisions { get; set; }

        public CreateRoleCommand()
        {
            Permisions = new Dictionary<string, IEnumerable<string>>();
        }
    }
}
