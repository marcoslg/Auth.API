using Auth.Application.Contracts;
using Auth.Application.Roles.Queries.Models;
using Auth.Application.Roles.Queries.SearchRole.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Queries.SearchRole
{
    public class SearchRolesQueryHandler : IRequestHandler<SearchRolesQuery, IEnumerable<RoleVM>>
    {
        private readonly IAppDbContext _context;
        public SearchRolesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RoleVM>> Handle(SearchRolesQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.ToLowerInvariant();
            
            var result = await _context.Roles.AsNoTracking()
                .Where(r => r.IsEnabled && r.Name.Contains(normalizedName))
                .OrderBy(r => r.Name)
                .ToMap()
                .ToListAsync(cancellationToken);
            return result;
        }
    }
}
