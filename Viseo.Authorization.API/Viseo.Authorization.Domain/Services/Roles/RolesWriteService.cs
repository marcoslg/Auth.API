using System;
using System.Threading.Tasks;
using Viseo.Authorization.Domain.Contracts;
using Viseo.Authorization.Domain.Exceptions;
using Viseo.Authorization.Domain.Validations.Roles;

namespace Viseo.Authorization.Domain.Services.Roles
{
    public class RolesWriteService
    {
        private readonly IRoleRepository _roleRepository;

        public RolesWriteService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository ?? throw new RoleException($"ctro: {nameof(roleRepository)} cannot be null");
        }

        public async Task Add(Role role)
        {
            CheckNull(role);
            var validation = role.Validate();
            validation.Check();
            var exists = await _roleRepository.Exists(role.Name).ConfigureAwait(false);
            if (!exists)
            {
                await _roleRepository.Add(role).ConfigureAwait(false);
            }
            else
            {
                throw new RoleAlredyExistsException(role.Name);
            }
        }

        public async Task Update(Role role)
        {
            CheckNull(role);
            var validation = role.Validate();
            validation.Check();
            var exists = await _roleRepository.Exists(role.Name).ConfigureAwait(false);
            if (exists)
            {
                await _roleRepository.Update(role).ConfigureAwait(false);
            }
            else
            {
                throw new RoleNotFoundException(role.Name);
            }
        }

        private void CheckNull(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException($"{nameof(role)} cannot be null");
            }
        }
    }
}
