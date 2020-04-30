using MediatR;

namespace Auth.Application.Roles.Commands.Enabled
{
    public class EnabledRoleCommand : IRequest
    {
        public string Name { get; set; }
    }
}
