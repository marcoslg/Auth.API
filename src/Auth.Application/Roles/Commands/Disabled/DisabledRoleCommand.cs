using MediatR;

namespace Auth.Application.Roles.Commands.Delete
{
    public class DisabledRoleCommand : IRequest
    {
        public string Name { get; set; }
    }
}
