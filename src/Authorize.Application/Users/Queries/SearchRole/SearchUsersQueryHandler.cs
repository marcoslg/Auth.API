using Authorize.Application.Contracts;
using Authorize.Application.Extensions;
using Authorize.Application.Users.Queries.Models;
using Authorize.Application.Users.Queries.SearchRole.Models;
using Authorize.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Users.Queries.SearchRole
{
    public class SearchUsersQueryHandler : IRequestHandler<SearchUsersQuery, IEnumerable<UserVM>>
    {
        private readonly IAppDbContext _context;
        public SearchUsersQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserVM>> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            
            Expression<Func<User, bool>> whereExpresion = BuildExpresion(request);
            var result = await _context.Users.AsNoTracking()
                .Where(whereExpresion)
                .ToMap(request.PageSize, request.Page)
                .ToListAsync(cancellationToken);
            return result;
        }

        private Expression<Func<User, bool>> BuildExpresion(SearchUsersQuery request)
        {
            var normalizedName = request.UserName;
            Expression<Func<User, bool>> whereExpresion = r => r.IsEnabled;
            if (!string.IsNullOrWhiteSpace(normalizedName))
            {
                whereExpresion.And(r => r.UserName.Contains(normalizedName));
            }
            return whereExpresion;
        }
    }
}
