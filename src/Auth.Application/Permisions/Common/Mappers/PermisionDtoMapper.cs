using Auth.Application.Permisions.Common.Models;
using Auth.Domain.Applications;

namespace Auth.Application.Permisions.Common.Mappers
{
    internal static class PermisionDtoMapper
    {
        public static PermissionDto ToMap(this Permision permision)
            => new PermissionDto()
            {
                Name = permision.Name,
                Description = permision.Description
            };
    }
}
