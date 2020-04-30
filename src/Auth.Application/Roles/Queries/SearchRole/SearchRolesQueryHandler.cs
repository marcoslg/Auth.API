using Auth.Application.Contracts;
using Auth.Application.Extensions;
using Auth.Application.Roles.Queries.Models;
using Auth.Application.Roles.Queries.SearchRole.Models;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var normalizedName = request.Name?.ToLowerInvariant();
            Expression<Func<Role, bool>> whereExpresion = BuildExpresion(request);
            var result = await _context.Roles.AsNoTracking()
                .Where(whereExpresion)              
                .ToMap(request.PageSize, request.Page)
                .ToListAsync(cancellationToken);
            return result;
        }

        private Expression<Func<Role, bool>> BuildExpresion(SearchRolesQuery request)
        {
            var normalizedName = request.Name?.ToLowerInvariant();
            Expression<Func<Role, bool>> whereExpresion = r => r.IsEnabled;
            if (!string.IsNullOrWhiteSpace(normalizedName))
            {
                whereExpresion.And(r => r.IsEnabled && r.Name.Contains(normalizedName));
            }            
            return whereExpresion;
        }
    }
}
