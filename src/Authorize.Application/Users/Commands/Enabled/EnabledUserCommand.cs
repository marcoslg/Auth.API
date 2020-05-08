using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Users.Commands.Enabled
{
    [Authorize(AuthPermisions.UserEnabled)]
    public class EnabledUserCommand : IRequest
    {
        public string UserName { get; set; }
    }
}
