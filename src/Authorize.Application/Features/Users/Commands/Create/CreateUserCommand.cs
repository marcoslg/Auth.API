using Authorize.Application.Attributtes;
using MediatR;
using System.Collections.Generic;

namespace Authorize.Application.Features.Users.Commands.Create
{
    [Authorize(AuthPermissions.UserCreated)]
    public class CreateUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public List<string> RoleNames { get; set; }
    }
}
