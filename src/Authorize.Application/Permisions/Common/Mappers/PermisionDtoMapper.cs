using Authorize.Application.Permisions.Common.Models;
using Authorize.Domain.Applications;

namespace Authorize.Application.Permisions.Common.Mappers
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
