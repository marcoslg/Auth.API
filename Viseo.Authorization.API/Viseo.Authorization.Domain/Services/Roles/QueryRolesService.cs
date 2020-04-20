using System.Collections.Generic;
using System.Threading.Tasks;
using Viseo.Authorization.Domain.Contracts;
using Viseo.Authorization.Domain.Exceptions;

namespace Viseo.Authorization.Domain.Services.Roles
{
    public class QueryRolesService
    {
        private readonly IRoleRepository _roleRepository;

        public QueryRolesService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository ?? throw new RoleException($"ctro: {nameof(roleRepository)} cannot be null");
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            var roles = await _roleRepository.GetAll().ConfigureAwait(false);
            return roles;
        }

        public async Task<Role> Get(string name)
        {
            var role = await _roleRepository.Get(name).ConfigureAwait(false);
            return role;
        }
    }
}
