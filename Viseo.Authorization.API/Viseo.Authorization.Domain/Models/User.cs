using System;
using System.Collections.Generic;
using System.Text;

namespace Viseo.Authorization.Domain.Models
{
    public class User
    {
        public string UserName { get; set; }
        public IEnumerable<Role> Roles { get; set; }

        public User()
            : this(null)
        {            
        }
        public User(string userName)
            :this(userName, new List<Role>())
        {

        }
        public User(string usernName, IEnumerable<Role> roles)
        {
            UserName = usernName;
            Roles = roles;
        }
    }
}
