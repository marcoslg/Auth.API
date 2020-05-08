using Authorize.Domain.Common;
using Authorize.Domain.Roles;
using System.Collections.Generic;

namespace Authorize.Domain.Users
{
    public class User : AuditableEntity
    {
        private string _userName;
        public string UserName 
        {
            get => _userName;
            private set => _userName = value?.ToLowerInvariant();
        }

        public User(string username)
          : this (username, null)
        {

        }
        public User(string username, ICollection<Role> roles)
        {
            UserName = username;
            Roles = roles ?? new List<Role>();
        }

        public ICollection<Role> Roles { get; set; }
    }
}
