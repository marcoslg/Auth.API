using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Applications.Commands.Enabled
{
    public class EnabledApplicationCommandHandler : IRequestHandler<EnabledApplicationCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _cuserService;
        public EnabledApplicationCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
            _cuserService = cuserService;
        }
        public async Task<Unit> Handle(EnabledApplicationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Applications
                 .FirstOrDefaultAsync(ap => ap.Name == command.Name, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Applications.Application), command.Name);
            }
            cancellationToken.ThrowIfCancellationRequested();
            entity.IsEnabled = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}