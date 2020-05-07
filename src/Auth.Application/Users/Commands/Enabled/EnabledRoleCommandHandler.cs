using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Users.Commands.Enabled
{
    public class EnabledUserCommandHandler : IRequestHandler<EnabledUserCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _cuserService;
        public EnabledUserCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
            _cuserService = cuserService;
        }
        public async Task<Unit> Handle(EnabledUserCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                 .FirstOrDefaultAsync(r => r.UserName == command.UserName, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), command.UserName);
            }
            cancellationToken.ThrowIfCancellationRequested();
            entity.IsEnabled = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
