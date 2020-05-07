using Auth.Application.Attributtes;
using MediatR;
using System.Collections.Generic;

namespace Auth.Application.Users.Commands.Create
{
    [Authorize(AuthPermisions.UserCreated)]
    public class CreateUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public List<string> RoleNames { get; set; }
    }
}
