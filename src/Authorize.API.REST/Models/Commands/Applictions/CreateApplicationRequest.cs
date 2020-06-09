using Authorize.Application.Features.Common.Models;
using System.Collections.Generic;

namespace Authorize.API.REST.Models.Commands.Applictions
{
    public class CreateApplicationRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<PermissionDto> Permissions { get; set; }
    }
}
