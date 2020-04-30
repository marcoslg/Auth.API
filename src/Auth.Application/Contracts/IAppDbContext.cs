using Auth.Domain.Roles;
using Auth.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Contracts
{
    public interface IAppDbContext 
    {
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<Domain.Applications.Application> Applications { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
