using Auth.Domain.Roles;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Auth.Domain.Users
{
    public class User : IdentityUser<string>
    {

        public override string Id
        {
            get => UserName;
            set => UserName = value;
        }

        public IEnumerable<Role> Roles { get; set; }
    }
}
