using Auth.Application.Attributtes;
using MediatR;

namespace Auth.Application.Applications.Commands.Enabled
{
    [Authorize(AuthPermisions.RoleEnabled)]
    public class EnabledApplicationCommand : IRequest
    {
        public string Name { get; set; }
    }
}