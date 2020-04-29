using Auth.Domain.Common;
using Auth.Domain.Roles;
using System.Collections.Generic;

namespace Auth.Domain.Users
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
        public User(string username, IEnumerable<Role> roles)
        {
            UserName = username;
            Roles = roles ?? new List<Role>();
        }

        public IEnumerable<Role> Roles { get; set; }
    }
}
