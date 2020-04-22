using Auth.Application.Exceptions;
using Auth.Application.Extensions;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Commands.Delete
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        
        private readonly RoleManager<Domain.Roles.Role> _roleManager;
        public DeleteRoleCommandHandler(RoleManager<Domain.Roles.Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Unit> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _roleManager.FindByNameAsync(command.Name);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), command.Name);
            }
            cancellationToken.ThrowIfCancellationRequested();            
            var result = await _roleManager.DeleteAsync(entity);
            result.ThrowIfError();
            return Unit.Value;
        }
    }
}
