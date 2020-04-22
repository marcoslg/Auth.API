using Auth.Domain.Roles;
using Auth.Domain.Users;

namespace Auth.Application.Contracts
{
    public interface IAppDbContext : IDbContext<Role>, IDbContext<User>
    {
    }
}
