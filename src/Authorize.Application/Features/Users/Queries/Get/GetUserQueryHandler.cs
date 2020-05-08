using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using Authorize.Application.Features.Users.Queries.Get.Models;
using Authorize.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Users.Queries.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserWithRolesVM>
    {
        private readonly IAppDbContext _context;
        public GetUserQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<UserWithRolesVM> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.AsNoTracking()
                .Include(r => r.Roles)
                .SingleOrDefaultAsync(r => r.UserName == request.UserName, cancellationToken);
            if (user == null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                throw new NotFoundException(nameof(User), request.UserName);
            }
            var result = user.ToMap();
            cancellationToken.ThrowIfCancellationRequested();
            return result;
        }
    }
}
