using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorize.API.REST.Models.Commands.Roles
{
    public class CreateRoleRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, IEnumerable<string>> Permissions { get; set; }

        public CreateRoleRequest()
        {
            Permissions = new Dictionary<string, IEnumerable<string>>();
        }
    }
}
