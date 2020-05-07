using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Users.Commands.Enabled
{
    [Authorize(AuthPermisions.UserEnabled)]
    public class EnabledUserCommand : IRequest
    {
        public string UserName { get; set; }
    }
}
