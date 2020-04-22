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
        public string Description { get; set; }
        public IEnumerable<ApplicationRole> Applications { get; set; }
        public Role()
        {
        }

        public Role(string roleName) : base(roleName)
        {

        }

        public Role(string roleName, string description, IEnumerable<ApplicationRole> applications = null) : base(roleName)
        {
            Description = description;
            this.NormalizedName = roleName.ToLowerInvariant();
            Applications = applications ?? new List<ApplicationRole>();
        }

        

    }
    public class RoleClaim : IdentityRoleClaim<string>
    {
        
    }
}
