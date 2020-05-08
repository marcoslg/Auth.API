using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Applications.Commands.Disabled
{
    public class DisabledApplicationCommandHandler : IRequestHandler<DisabledApplicationCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _cuserService;
        public DisabledApplicationCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
            _cuserService = cuserService;
        }
        public async Task<Unit> Handle(DisabledApplicationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Applications
                 .FirstOrDefaultAsync(ap => ap.Name == command.Name, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Applications.Application), command.Name);
            }
            cancellationToken.ThrowIfCancellationRequested();
            entity.IsEnabled = false;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}