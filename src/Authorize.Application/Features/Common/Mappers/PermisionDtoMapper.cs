using Authorize.Application.Features.Common.Models;
using Authorize.Domain.Applications;

namespace Authorize.Application.Features.Common.Mappers
{
    internal static class PermisionDtoMapper
    {
        public static PermissionDto ToMap(this Permission permision)
            => new PermissionDto()
            {
                Name = permision.Name,
                Description = permision.Description
            };
    }


    internal static class PermisionMapper
    {
        public static Permission ToMap(this PermissionDto permision)
            => Permission.For(permision.Name, permision.Description);
    }
}
