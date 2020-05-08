using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Roles.Commands.Enabled
{
    [Authorize(AuthPermisions.RoleEnabled)]
    public class EnabledRoleCommand : IRequest
    {
        public string Name { get; set; }
    }
}
