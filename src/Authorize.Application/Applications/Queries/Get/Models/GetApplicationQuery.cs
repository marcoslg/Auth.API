using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Applications.Queries.Get.Models
{
    [Authorize(AuthPermisions.ApplicationGet)]
    public class GetApplicationQuery : IRequest<ApplicationPermisionsVM>
    {
        public string Name { get; set; }
    }
}