using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Features.Applications.Queries.Get.Models
{
    [Authorize(AuthPermissions.ApplicationGet)]
    public class GetApplicationQuery : IRequest<ApplicationPermissionsVM>
    {
        public string Name { get; set; }

        public GetApplicationQuery()
        {

        }
        public GetApplicationQuery(string applicationName)
        {
            Name = applicationName;
        }
    }
}