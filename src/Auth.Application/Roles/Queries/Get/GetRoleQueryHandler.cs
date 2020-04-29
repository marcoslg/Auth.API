using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Application.Roles.Queries.Get.Models;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Queries.Get
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleVM>
    {
        private readonly IAppDbContext _context;
        public GetRoleQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<RoleVM> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.ToLowerInvariant();
            cancellationToken.ThrowIfCancellationRequested();
            var role = await _context.Roles.AsNoTracking()
                .SingleOrDefaultAsync(r => r.Name == normalizedName, cancellationToken);            
            if (role == null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                throw new NotFoundException(nameof(Role), request.Name);
            }
            var result = role.ToMap();
            cancellationToken.ThrowIfCancellationRequested();
            return result;
        }
    }
}
