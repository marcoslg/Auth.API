﻿using Authorize.Application.Contracts;
using Authorize.Application.Extensions;
using Authorize.Application.Features.Applications.Queries.Models;
using Authorize.Application.Features.Applications.Queries.SearchRole.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Applications.Queries.SearchRole
{
    public class SearchApplicationsQueryHandler : IRequestHandler<SearchApplicationsQuery, IEnumerable<ApplicationVM>>
    {
        private readonly IAppDbContext _context;
        public SearchApplicationsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ApplicationVM>> Handle(SearchApplicationsQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name?.ToLowerInvariant();
            Expression<Func<Domain.Applications.Application, bool>> whereExpresion = BuildExpresion(request);
            var result = await _context.Applications.AsNoTracking()
                .Where(whereExpresion)
                .ToMap(request.PageSize, request.Page)
                .ToListAsync(cancellationToken);
            return result;
        }

        private Expression<Func<Domain.Applications.Application, bool>> BuildExpresion(SearchApplicationsQuery request)
        {
            var normalizedName = request.Name?.ToLowerInvariant();
            Expression<Func<Domain.Applications.Application, bool>> whereExpresion = r => r.IsEnabled;
            if (!string.IsNullOrWhiteSpace(normalizedName))
            {
                whereExpresion.And(ap => ap.Name.Contains(normalizedName));
            }
            return whereExpresion;
        }
    }
}