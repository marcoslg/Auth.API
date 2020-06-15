using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using Authorize.Application.Features.Common.Mappers;
using Authorize.Application.Features.Common.Models;
using Authorize.Application.Features.Permissions.Queries.GetByUser.Models;
using Authorize.Domain.Applications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Permissions.Queries.GetByUser
{
    public class GetPermissionsHandler : IRequestHandler<GetPermissionsQuery, IEnumerable<PermissionDto>>
    {
        private readonly IAppDbContext _context;

        public GetPermissionsHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var username = request.Username.ToLowerInvariant();
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == username && u.IsEnabled, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), username);
            }
            if (!user.IsEnabled)
            {
                throw new DisabledException(nameof(user), username);
            }

            var tmp = _context.Roles.Include(r => r.Users)
                .Include(r => r.Applications).ToList();
            var roles = await _context.Roles.AsNoTracking()
                .Where(r => r.IsEnabled && r.Users.Any(u => u.User.UserName == user.UserName)
                   && r.Applications.Any(a => a.Application.Name == request.ApplicationName && a.Application.IsEnabled))
                .Include(r => r.Applications)
                    .ThenInclude(a => a.Permissions)
                    .ToListAsync(cancellationToken);

            var permisions = new HashSet<Permission>(
                roles
                .SelectMany(r => r.Applications
                    .SelectMany(a => a.Permissions)));
            cancellationToken.ThrowIfCancellationRequested();
            var permisionDtos = permisions.Select(p => p.ToMap());
            return permisionDtos;

        }
    }
}
