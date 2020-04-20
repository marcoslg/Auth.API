using System.Threading.Tasks;
using Viseo.Authorization.Domain.Contracts;
using Viseo.Authorization.Domain.Exceptions.Permissions;
using Viseo.Authorization.Domain.Models;

namespace Viseo.Authorization.Domain.Services
{
    public class PermissionsService
    {
        private readonly IUsersRepository _permissionsRepository;
        private readonly UsersService _usersService;
        private readonly ResourcesService _resourcesService;


        public async Task<ResourcePermission> GetByUser(string resourceName, string userName)
        {
            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new PermissionException($"{nameof(resourceName)} cannot be null or empry");
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new PermissionException($"{nameof(userName)} cannot be null or empry");
            }
            var user = await _usersService.Get(userName).ConfigureAwait(false);
            var rolePermisions = await _resourcesService.GetRolesPermision(resourceName, user.Roles).ConfigureAwait(false);
            ResourcePermission result = new ResourcePermission();
            foreach(var item in rolePermisions)
            {
                result = item.ResourcePermission + result;
            }
            return result;
        }
    }
}
