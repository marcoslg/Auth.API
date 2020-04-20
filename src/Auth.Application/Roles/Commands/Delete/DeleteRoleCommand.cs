using MediatR;

namespace Auth.Application.Roles.Commands.Delete
{
    public class DeleteRoleCommand : IRequest
    {
        public string Name { get; set; }
    }
}
