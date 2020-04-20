using System.Threading.Tasks;
using Viseo.Authorization.Domain.Models;

namespace Viseo.Authorization.Domain.Contracts
{
    public interface IUsersRepository
    {
        Task<User> Get(string userName);
        Task Add(User user);
        Task<bool> Exists(string userName);
        Task AddRole(string userName, Role role);
        Task RemoveRole(string userName, Role role);
    }
}
