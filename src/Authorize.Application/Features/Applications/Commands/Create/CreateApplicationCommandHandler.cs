using Authorize.Application.Contracts;
using Authorize.Application.Exceptions;
using Authorize.Application.Features.Applications.Commands.Create.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Authorize.Application.Features.Applications.Commands.Create
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _cuserService;
        public CreateApplicationCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
            _cuserService = cuserService;
        }
        public async Task<Unit> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            var exists = await _context.Applications
                 .AnyAsync(ap => ap.Name == command.Name, cancellationToken);
            if (exists)
            {
                throw new ExistsException(nameof(Domain.Applications.Application), command.Name);
            }
            cancellationToken.ThrowIfCancellationRequested();
            var model = command.ToMap();
            _context.Applications.Add(model);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}