using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using Authorize.Application.Features.Common.Mappers;
using Authorize.Application.Features.Common.Models;
using Authorize.Application.Features.Permissions.Queries.GetByApplication.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Permissions.Queries.GetByApplication
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
                .Include(a => a.Permissions)
                .FirstOrDefaultAsync(u => u.Name == request.ApplicationName, cancellationToken);
            if (app == null)
            {
                throw new NotFoundException(nameof(Domain.Applications.Application), request.ApplicationName);
            }
            cancellationToken.ThrowIfCancellationRequested();
            var permisionDtos = app.Permissions.Select(p => p.ToMap());
            return permisionDtos;
        }
    }
}
