using Auth.Domain.Applications;
using System.Collections.Generic;

namespace Auth.Domain.Roles
{
    public class ApplicationRole
    {
        public Application Application { get; set; }
        public IEnumerable<Permision> Permisions { get; set; }
    }
}
