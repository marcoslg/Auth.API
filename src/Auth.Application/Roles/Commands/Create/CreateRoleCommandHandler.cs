using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Commands.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
    {
        private readonly IRoleDbContext _roleContext;
        public CreateRoleCommandHandler(IRoleDbContext roleContext)
        {
            _roleContext = roleContext;
        }
        public async Task<string> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _roleContext
                .Roles
                .SingleOrDefaultAsync(r => r.Id == command.Name, cancellationToken);

            if (entity == null)
            {
                throw new ExistsException(nameof(Role), command.Name);
            }
            var role = command.ToMapRole();
            var roleClaims = command.ToMapRoleClaim();            
            await _roleContext.AddAsync(role, cancellationToken);

            await _roleContext.AddAsync(roleClaims, cancellationToken);
            await _roleContext.SaveChangesAsync(cancellationToken);

            return role.Name;
        }
    }
}
