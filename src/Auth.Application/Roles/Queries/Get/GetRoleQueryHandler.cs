using Auth.Application.Exceptions;
using Auth.Application.Roles.Queries.Get.Models;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Queries.Get
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleVM>
    {
        
        private readonly RoleManager<Domain.Roles.Role> _roleManager;
        public GetRoleQueryHandler(RoleManager<Domain.Roles.Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<RoleVM> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.ToLowerInvariant();
            cancellationToken.ThrowIfCancellationRequested();
            var role = await _roleManager.FindByNameAsync(request.Name);
            cancellationToken.ThrowIfCancellationRequested();
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
