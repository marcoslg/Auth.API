using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorize.API.REST.Models.Commands.Users
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public List<string> RoleNames { get; set; }        
    }
}
