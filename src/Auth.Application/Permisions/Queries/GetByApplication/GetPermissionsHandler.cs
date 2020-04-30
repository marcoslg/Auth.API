using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Application.Permisions.Common.Mappers;
using Auth.Application.Permisions.Common.Models;
using Auth.Application.Permisions.Queries.GetByApplication.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Permisions.Queries.GetByApplication
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
            
            var app = await _context.Applications
                .AsNoTracking()
                .Include(a => a.Permisions)
                .FirstOrDefaultAsync(u => u.Name == request.ApplicationName, cancellationToken);
            if (app == null)
            {
                throw new NotFoundException(nameof(Domain.Applications.Application), request.ApplicationName);
            }            
            cancellationToken.ThrowIfCancellationRequested();
            var permisionDtos = app.Permisions.Select(p => p.ToMap());
            return permisionDtos;
        }
    }
}
