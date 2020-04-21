using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Auth.Domain.Roles
{
    public class Role : IdentityRole<string>
    {
        public override string Id
        {
            get => Name;
            set => Name = value;
        }
        public Role()
        {
        }

        public Role(string roleName) : base(roleName)
        {

        }

        public Role(string roleName, string description) : base(roleName)
        {
            Description = description;
            this.NormalizedName = roleName.ToLowerInvariant();
        }

        public string Description { get; set; }
       
    }
    public class RoleClaim : IdentityRoleClaim<string>
    {
        
    }
}
