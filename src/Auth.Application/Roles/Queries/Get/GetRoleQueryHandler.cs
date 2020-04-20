using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Application.Roles.Queries.Get;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Queries.Get
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleVM>
    {
        private readonly IRoleDbContext _roleContext;
        public GetRoleQueryHandler(IRoleDbContext roleContext)
        {
            _roleContext = roleContext;
        }
        public async Task<RoleVM> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.ToLowerInvariant();
            var role = await _roleContext.Roles
                .FirstOrDefaultAsync(r => r.Name == request.Name, cancellationToken);
            if (role == null)
            {
                throw new NotFoundException(nameof(Role), request.Name);
            }
            var result = role.ToMap();
            return result;
        }
    }
}
