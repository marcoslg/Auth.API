using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using Authorize.Application.Features.Applications.Queries.Get.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Applications.Queries.Get
{
    public class GetApplicationQueryHandler : IRequestHandler<GetApplicationQuery, ApplicationPermissionsVM>
    {
        private readonly IAppDbContext _context;
        public GetApplicationQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationPermissionsVM> Handle(GetApplicationQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name;
            cancellationToken.ThrowIfCancellationRequested();
            var application = await _context.Applications.AsNoTracking()
                .Include(ap => ap.Permissions)
                .SingleOrDefaultAsync(ap => ap.Name == normalizedName, cancellationToken);
            if (application == null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                throw new NotFoundException(nameof(Domain.Applications.Application), request.Name);
            }
            var result = application.ToMap();
            cancellationToken.ThrowIfCancellationRequested();
            return result;
        }
    }
}