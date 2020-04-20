using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viseo.Authorization.Domain.Models;
using Viseo.Authorization.Domain.Models.Roles;

namespace Viseo.Authorization.Domain.Services
{
    public class ResourcesService
    {
        public Task<IEnumerable<ResourceRolePermision>> GetRolesPermision(string resourceName, IEnumerable<Role> roles)
        {
            ConcurrentBag<ResourceRolePermision> resourceRoles = new ConcurrentBag<ResourceRolePermision>();
            Parallel.ForEach(roles, (role) => AddRole(role, resourceRoles, resourceName));

            return Task.FromResult((IEnumerable<ResourceRolePermision>) resourceRoles.ToList());
        }

        private void AddRole(Role role, ConcurrentBag<ResourceRolePermision> resourceRoles, string resourceName)
        {
            if (!role.IsDisabled)
            {
                if (role is ResourceRolePermision resourceRole && CheckResource(resourceRole.Resource, resourceName))
                {
                    resourceRoles.Add(resourceRole);
                }
                else if (role is Group group && group.Roles.ContainsKey(resourceName))
                {
                    var resourceRolesGroup = group.Roles[resourceName];
                    if (resourceRolesGroup.Any() && CheckResource(resourceRolesGroup.First().Resource, resourceName))
                    {
                        foreach(var roleFromGroup in group.Roles[resourceName])
                        {
                            resourceRoles.Add(roleFromGroup);
                        }
                        
                    }
                }
            }
        }
        private bool CheckResource(Resource resource, string resourceName)
            => !resource.IsDisabled && resource.Name == resourceName;

    }
}
