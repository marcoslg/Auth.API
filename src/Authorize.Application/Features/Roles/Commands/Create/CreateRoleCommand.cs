using Authorize.Application.Attributtes;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Roles.Commands.Create
{
    [Authorize(AuthPermissions.RoleCreated)]
    public class CreateRoleCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private Dictionary<string, IEnumerable<string>> _permissions;
        public Dictionary<string, IEnumerable<string>> Permissions 
        {
            get => _permissions;
            set
            {
                if (value != null)
                {
                    _permissions = value;
                }

            }
        }

        public CreateRoleCommand()
        {
            Permissions = new Dictionary<string, IEnumerable<string>>();
        }

        public CreateRoleCommand(string name, string description, Dictionary<string, IEnumerable<string>> permissions)
        {
            Name = name;
            Description = description;
            Permissions = permissions;
        }
    }
}
