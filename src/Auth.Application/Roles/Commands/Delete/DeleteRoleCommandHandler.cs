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
        private readonly IRoleDbContext _roleContext;
        public DeleteRoleCommandHandler(IRoleDbContext roleContext)
        {
            _roleContext = roleContext;
        }
        public async Task<Unit> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _roleContext
                .Roles
                .SingleOrDefaultAsync(r => r.Id == command.Name, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), command.Name);
            }
            await _roleContext.RemoveAsync(entity, cancellationToken);
            return Unit.Value;
        }
    }
}
