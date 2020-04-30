using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Application.Permisions.Common.Mappers;
using Auth.Application.Permisions.Common.Models;
using Auth.Application.Permisions.Queries.GetByUser.Models;
using Auth.Domain.Applications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Permisions.Queries.GetByUser
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
                .FirstOrDefaultAsync(u => u.UserName == username, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), username);
            }
            if (user.IsEnabled)
            {
                throw new LockedException(nameof(user), username);
            }

            var roles = await _context.Roles.AsNoTracking()
                .Where(r => r.Users.Any(u => u.UserName == user.UserName)
                   && r.Applications.Any(a => a.Application.Name == request.ApplicationName && a.Application.IsEnabled))
                .Include(r => r.Applications)
                    .ThenInclude(a => a.Permisions)
                    .ToListAsync(cancellationToken);

            var permisions = new HashSet<Permision>(
                roles
                .SelectMany(r => r.Applications
                    .SelectMany(a => a.Permisions)));
            cancellationToken.ThrowIfCancellationRequested();
            var permisionDtos = permisions.Select(p => p.ToMap());
            return permisionDtos;

        }
    }
}
