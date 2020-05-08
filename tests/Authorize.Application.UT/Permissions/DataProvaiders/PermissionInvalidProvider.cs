using Authorize.Application.Permisions.Commands.AddPermissionInRole;
using System.Collections.Generic;
using Xunit;

namespace Authorize.Application.UT.Permissions.DataProvaiders
{
    public class PermissionInvalidProvider : TheoryData<AddPermissionRoleCommand>
    {

        public PermissionInvalidProvider()
        {
            Add(new AddPermissionRoleCommand()
            {
                RoleName = "guest",
                Permisions = new Dictionary<string, IEnumerable<string>>()
               {
                   {"Api1", new List<string>(){"read" } }
               }
            });

            Add(new AddPermissionRoleCommand()
            {
                RoleName = "guest",
                Permisions = new Dictionary<string, IEnumerable<string>>()
               {
                   {"Api1", new List<string>(){"read" } },
                   {"Authorize.application", new List<string>()
                        {
                            AuthPermisions.RoleGet,
                            AuthPermisions.RoleSearch,
                            AuthPermisions.UserGet,
                            AuthPermisions.UserSearch
                        }
                   }
               }
            });
        }
    }
}
