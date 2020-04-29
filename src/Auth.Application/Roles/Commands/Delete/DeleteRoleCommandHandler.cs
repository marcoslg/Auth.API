using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Commands.Delete
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {

        private readonly IAppDbContext _context;
        public DeleteRoleCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Roles
                 .FirstOrDefaultAsync(r => r.Name == command.Name, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), command.Name);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
