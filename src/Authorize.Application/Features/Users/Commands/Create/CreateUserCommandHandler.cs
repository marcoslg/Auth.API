using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using Authorize.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IAppDbContext _context;
        public CreateUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(r => r.UserName == command.UserName, cancellationToken);
            if (entity != null)
            {
                throw new ExistsException(nameof(User), command.UserName);
            }
            var user = command.ToMap();
            _context.Users.Add(user);
            cancellationToken.ThrowIfCancellationRequested();
            await _context.SaveChangesAsync(cancellationToken);
            return user.UserName;
        }
    }
}
