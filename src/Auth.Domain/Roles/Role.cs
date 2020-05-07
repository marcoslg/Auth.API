using Auth.Domain.Common;
using Auth.Domain.Users;
using System.Collections.Generic;

namespace Auth.Domain.Roles
{
    public class Role : AuditableEntity
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set => _name = value?.ToLowerInvariant();
        }
        public string Description { get; set; }
        public IEnumerable<ApplicationRole> Applications { get; set; }        

        public Role(string roleName)
            : this(roleName, string.Empty)
        {
        }

        public Role(string roleName, string description, IEnumerable<ApplicationRole> applications = null)
        {
            Name = roleName;
            Description = description;
            Applications = applications ?? new List<ApplicationRole>();
            IsEnabled = true;
            Users = new List<User>();
        }

        public IEnumerable<User> Users { get; set; }


    }  
}
