using Authorize.Application.Features.Common.Mappers;
using System.Linq;

namespace Authorize.Application.Features.Applications.Commands.Create.Mappers
{
    internal static class CreateApplicationCommandMapper
    {
        public static Domain.Applications.Application ToMap(this CreateApplicationCommand command)
        => new Domain.Applications.Application(command.Name)
        {
            Description = command.Description,
            Permissions = command.Permissions.Select(p => p.ToMap()).ToList()
        };
    }
}
