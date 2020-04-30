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
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _cuserService;
        public CreateRoleCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Roles.AsNoTracking()
                .FirstOrDefaultAsync(r => r.Name == command.Name, cancellationToken);            
            if (entity != null)
            {
                throw new ExistsException(nameof(Role), command.Name);
            }
            var role = command.ToMap();            
            _context.Roles.Add(role);
            cancellationToken.ThrowIfCancellationRequested();
            await _context.SaveChangesAsync(cancellationToken);
            return role.Name;
        }
    }
}
