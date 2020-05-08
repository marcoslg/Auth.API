using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Features.Applications.Queries.Get.Models
{
    [Authorize(AuthPermisions.ApplicationGet)]
    public class GetApplicationQuery : IRequest<ApplicationPermisionsVM>
    {
        public string Name { get; set; }
    }
}