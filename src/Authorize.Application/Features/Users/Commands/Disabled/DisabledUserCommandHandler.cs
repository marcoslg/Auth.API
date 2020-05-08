using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using Authorize.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Users.Commands.Disabled
{
    public class DisabledUserCommandHandler : IRequestHandler<DisabledUserCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _cuserService;
        public DisabledUserCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
            _cuserService = cuserService;
        }
        public async Task<Unit> Handle(DisabledUserCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                 .FirstOrDefaultAsync(r => r.UserName == command.UserName, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), command.UserName);
            }
            cancellationToken.ThrowIfCancellationRequested();
            entity.IsEnabled = false;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
