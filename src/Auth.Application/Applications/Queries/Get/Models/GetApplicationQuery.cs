using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Applications.Queries.Get.Models
{
    [Authorize(AuthPermisions.ApplicationGet)]
    public class GetApplicationQuery : IRequest<ApplicationPermisionsVM>
    {
        public string Name { get; set; }
    }
}