using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Users.Queries.Get.Models
{
    [Authorize(AuthPermisions.UserGet)]
    public class GetUserQuery : IRequest<UserWithRolesVM>
    {
        public string UserName { get; set; }
    }
}
