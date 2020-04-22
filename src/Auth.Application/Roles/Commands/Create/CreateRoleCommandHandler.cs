using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Application.Extensions;
using Auth.Domain.Roles;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Roles.Commands.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
    {
        
        private readonly RoleManager<Domain.Roles.Role> _roleManager;
        public CreateRoleCommandHandler(RoleManager<Domain.Roles.Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<string> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _roleManager.FindByNameAsync(command.Name);            
            if (entity == null)
            {
                throw new ExistsException(nameof(Role), command.Name);
            }
            var role = command.ToMap();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _roleManager.CreateAsync(role);
            result.ThrowIfError();
            return role.Name;
        }
    }
}
