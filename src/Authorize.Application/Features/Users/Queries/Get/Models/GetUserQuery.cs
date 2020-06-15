using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Features.Users.Queries.Get.Models
{
    [Authorize(AuthPermissions.UserGet)]
    public class GetUserQuery : IRequest<UserWithRolesVM>
    {
        public string UserName { get; set; }
    }
}
