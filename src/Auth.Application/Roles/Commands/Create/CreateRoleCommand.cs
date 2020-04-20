using MediatR;
using System.Collections.Generic;

namespace Auth.Application.Roles.Commands.Create
{
    public class CreateRoleCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, IEnumerable<string>> Permisions { get; set; }
    }
}
