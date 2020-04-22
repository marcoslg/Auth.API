using Auth.Application.Exceptions;
using Auth.Domain.Applications;
using Auth.Domain.Roles;
using Auth.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Permisions.Queries.Get
{
    public class GetPermissionsHandler : IRequestHandler<GetPermissionsQuery, IEnumerable<PermissionDto>>
    {        
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public GetPermissionsHandler(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IEnumerable<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Username);
            }
            if (user.LockoutEnabled)
            {
                throw new LockedException(nameof(user), request.Username);                
            }
            cancellationToken.ThrowIfCancellationRequested();
            var userRoles = await _userManager.GetRolesAsync(user);
            cancellationToken.ThrowIfCancellationRequested();
            var roles = await _roleManager.Roles
                .AsNoTracking()
                .Where(r => userRoles.Contains(r.Name) && r.Applications.Any(a => a.Application.Name == request.ApplicationName && a.Application.IsEnabled))
                .Include(r => r.Applications)
                    .ThenInclude(a => a.Permisions)
                    .ToListAsync(cancellationToken);

            var permisions = new HashSet<Permision>(
                roles
                .SelectMany(r=> r.Applications
                    .SelectMany(a=>a.Permisions)));
            cancellationToken.ThrowIfCancellationRequested();
            var permisionDtos = permisions.Select(p => p.ToMap());
            return permisionDtos;

        }
    }
}
