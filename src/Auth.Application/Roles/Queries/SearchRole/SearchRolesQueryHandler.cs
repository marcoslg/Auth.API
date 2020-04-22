using Auth.Application.Roles.Queries.SearchRole.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Queries.SearchRole
{
    public class SearchRolesQueryHandler : IRequestHandler<SearchRolesQuery, IEnumerable<RoleVM>>
    {        
        private readonly RoleManager<Domain.Roles.Role> _roleManager;
        public SearchRolesQueryHandler(RoleManager<Domain.Roles.Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IEnumerable<RoleVM>> Handle(SearchRolesQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name;
            
            var result = await _roleManager.Roles.AsNoTracking()
                .Where(r => r.Name.Contains(normalizedName))
                .OrderBy(r => r.Name)
                .ToMap()
                .ToListAsync(cancellationToken);
            return result;
        }
    }
}
