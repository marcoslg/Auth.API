using Authorize.Application.Attributtes;
using Authorize.Application.Features.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Applications.Commands.Create
{
    [Authorize(AuthPermissions.ApplicationCreated)]
    public class CreateApplicationCommand : IRequest
    {
        private IReadOnlyList<PermissionDto> _permissions;

        public string Name { get; internal set; }
        public string Description { get; internal set; }

        public IReadOnlyList<PermissionDto> Permissions 
        {
            get => _permissions;
            set
            {
                _permissions = value ?? new List<PermissionDto>();
            }
        }

        public CreateApplicationCommand(string name, string description, IReadOnlyList<PermissionDto> permissions)
        {
            Name = name;
            Description = description;
            Permissions = permissions;
        }
    }
}
