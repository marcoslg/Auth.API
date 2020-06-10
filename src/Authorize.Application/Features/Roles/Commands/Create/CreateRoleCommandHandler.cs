using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using Authorize.Application.Validators;
using Authorize.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Roles.Commands.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IAppDbContext _context;
        public CreateRoleCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Roles.AsNoTracking()
                .FirstOrDefaultAsync(r => r.Name == command.Name, cancellationToken);
            if (entity != null)
            {
                throw new ExistsException(nameof(Role), command.Name);
            }
            await new PermissionsExistsValidator(_context.Applications, command.Permissions, cancellationToken)
                .ValidAsync();

            var role = command.ToMap();
            _context.Roles.Add(role);

            cancellationToken.ThrowIfCancellationRequested();

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
