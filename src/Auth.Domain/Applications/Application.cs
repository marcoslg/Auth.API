using Auth.Domain;
using Auth.Domain.Common;
using System.Collections.Generic;

namespace Auth.Domain.Applications
{
    public class Application : AuditableEntity
    {
        public string Name { get; private set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        public Version Version { get; set; }
        public IEnumerable<Permision> Permisions { get; set; }

        public Application(string name)
        {
            Name = name;
            Permisions = new List<Permision>();
        }
    }
}
