using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Viseo.Authorization.Domain.Contracts
{
    public interface IRoleRepository
    {
        Task<bool> Exists(string name);
        Task<Role> Get(string name);
        Task<IEnumerable<Role>> GetAll();
        Task Add(Role role);
        Task Update(Role role);

    }
}
