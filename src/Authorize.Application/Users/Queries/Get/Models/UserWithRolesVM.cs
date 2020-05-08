using Authorize.Application.Roles.Queries.Models;
using Authorize.Application.Users.Queries.Models;
using System.Collections.Generic;

namespace Authorize.Application.Users.Queries.Get.Models
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
