using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Application.Roles.Queries.Get;
using Auth.Application.Roles.Queries.Get.Models;
using Auth.Application.Users.Queries.Get.Models;
using Auth.Domain.Roles;
using Auth.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Users.Queries.Get
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
