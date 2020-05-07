using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Users.Commands.Disabled
{
    [Authorize(AuthPermisions.UserDisabled)]
    public class DisabledUserCommand : IRequest
    {
        public string UserName { get; set; }
    }
}
