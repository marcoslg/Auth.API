using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Contracts
{
    public interface IDbContext<TEntity>
       where TEntity: class, new()
    {
        IQueryable<TEntity> Data();
        Task AddAsync(TEntity role, CancellationToken cancellationToken);
        Task RemoveAsync(TEntity role, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
