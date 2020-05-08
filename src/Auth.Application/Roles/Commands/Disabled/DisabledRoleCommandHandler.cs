﻿using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Commands.Delete
{
    public class DisabledRoleCommandHandler : IRequestHandler<DisabledRoleCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _cuserService;
        public DisabledRoleCommandHandler(IAppDbContext context, ICurrentUserService cuserService)
        {
            _context = context;
            _cuserService = cuserService;
        }
        public async Task<Unit> Handle(DisabledRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Roles                  
                 .FirstOrDefaultAsync(r => r.Name == command.Name, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), command.Name);
            }            
            cancellationToken.ThrowIfCancellationRequested();
            entity.IsEnabled = false;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}