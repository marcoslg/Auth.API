using Auth.Application.Roles.Queries.Models;
using Auth.Application.Users.Queries.Models;
using System.Collections.Generic;

namespace Auth.Application.Users.Queries.Get.Models
{
    public class UserWithRolesVM : UserVM
    {
        public UserWithRolesVM(string name, bool isEnabled, IEnumerable<RoleVM> roles)
            : base(name, isEnabled)
        {
            Roles = roles ?? new List<RoleVM>();
        }

        public IEnumerable<RoleVM> Roles { get; set; }


    }
}
