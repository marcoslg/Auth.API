using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using Authorize.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Roles.Commands.Enabled
{
    public class EnabledRoleCommandHandler : IRequestHandler<EnabledRoleCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _cuserService;
        public EnabledRoleCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
            _cuserService = cuserService;
        }
        public async Task<Unit> Handle(EnabledRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Roles
                 .FirstOrDefaultAsync(r => r.Name == command.Name, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), command.Name);
            }
            cancellationToken.ThrowIfCancellationRequested();
            entity.IsEnabled = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
