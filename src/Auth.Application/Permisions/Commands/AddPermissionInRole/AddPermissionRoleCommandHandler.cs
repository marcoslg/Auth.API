using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Application.Validators;
using Auth.Domain.Applications;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Permisions.Commands.AddPermissionInRole
{
    public class AddPermissionRoleCommandHandler : IRequestHandler<AddPermissionRoleCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _cuserService;
        public AddPermissionRoleCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
        }
        public async Task<Unit> Handle(AddPermissionRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == command.RoleName, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), command.RoleName);
            }
            await new PermissionsExistsValidator(_context.Applications, command.Permisions, cancellationToken)
                .ValidAsync();
            foreach (var app in command.Permisions)
            {
                cancellationToken.ThrowIfCancellationRequested();
                entity.Applications.Add(new ApplicationRole()
                {
                    Application = new Domain.Applications.Application(app.Key),
                    Permisions = app.Value.Select(p => Permision.For(p)).ToList()
                });
            }
            cancellationToken.ThrowIfCancellationRequested();
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }      
    }
}
