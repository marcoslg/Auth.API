using Auth.Application.Contracts;
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
        private IRoleDbContext _roleContext;
        public SearchRolesQueryHandler(IRoleDbContext roleContext)
        {
            _roleContext = roleContext;
        }
        public async Task<IEnumerable<RoleVM>> Handle(SearchRolesQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.ToLowerInvariant();
            var result = await _roleContext.Roles.AsNoTracking()
                .Where(r => r.NormalizedName.Contains(normalizedName))
                .OrderBy(r => r.Name)
                .ToMap()
                .ToListAsync(cancellationToken);
            return result;
        }
    }
}
