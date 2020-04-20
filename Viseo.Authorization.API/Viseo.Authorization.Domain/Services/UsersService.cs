using System.Collections.Generic;
using System.Threading.Tasks;
using Viseo.Authorization.Domain.Contracts;
using Viseo.Authorization.Domain.Exceptions.Users;
using Viseo.Authorization.Domain.Models;
using Viseo.Authorization.Domain.Validations.Roles;
using Viseo.Authorization.Domain.Validations.Users;

namespace Viseo.Authorization.Domain.Services
{
    public class UsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository ?? throw new UserException($"ctro: {nameof(usersRepository)} cannot be null");
        }

        public async Task<User> Get(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new UserArgumentException($"{nameof(userName)} cannot be null or empty");
            }
            var user = await _usersRepository.Get(userName).ConfigureAwait(false);
            if (user == null)
            {
                throw new UserNotFoundException($"user {userName} not found");
            }
            return user;
        }

        public async Task Add(User user)
        {
            if (user == null)
            {
                throw new UserArgumentException($"{nameof(user)} cannot be null");
            }
            user.Check();
            await AlreadyExists(user.UserName);
            await _usersRepository.Add(user).ConfigureAwait(false);
            var taskRoles = new List<Task>();
            foreach(var role in user.Roles)
            {
                taskRoles.Add(AddRole(user.UserName, role));
            }
            Task.WaitAll(taskRoles.ToArray());
        }

        public async Task AddRole(string userName, Role role)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new UserArgumentException($"{nameof(userName)} cannot be null or empty");
            }
            if (role == null)
            {
                throw new UserArgumentException($"{nameof(userName)} cannot be null or empty");
            }
            role.Check();
            await Exists(userName);
            await _usersRepository.AddRole(userName, role).ConfigureAwait(false);
        }

        public async Task RemoveRole(string userName, Role role)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new UserArgumentException($"{nameof(userName)} cannot be null or empty");
            }
            if (role == null)
            {
                throw new UserArgumentException($"{nameof(role)} cannot be null");
            }
            role.Check();
            await Exists(userName);
            await _usersRepository.RemoveRole(userName, role).ConfigureAwait(false);
        }

        private async Task Exists(string userName)
        {
            var exists = await _usersRepository.Exists(userName).ConfigureAwait(false);
            if (!exists)
            {
                throw new UserNotFoundException($"user {userName} not found");
            }
        }

        private async Task AlreadyExists(string userName)
        {
            var exists = await _usersRepository.Exists(userName).ConfigureAwait(false);
            if (exists)
            {
                throw new UserAlreadyExistsException($"user {userName} already exists");
            }
        }
    }
}
