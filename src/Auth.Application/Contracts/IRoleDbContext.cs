using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Contracts
{
    public interface IRoleDbContext
    {
        IQueryable<Domain.Roles.Role> Roles { get; }
        Task AddAsync(Domain.Roles.Role role, CancellationToken cancellationToken);
        Task RemoveAsync(Domain.Roles.Role role, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
