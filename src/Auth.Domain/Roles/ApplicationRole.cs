using Auth.Domain.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.Roles
{
    public class ApplicationRole
    {
        public Application Application { get; set; }
        public ICollection<Permision> Permisions { get; set; }
    }
}
