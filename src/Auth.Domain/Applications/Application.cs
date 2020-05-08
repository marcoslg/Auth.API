using Auth.Domain.Common;
using System.Collections.Generic;

namespace Auth.Domain.Applications
{
    public class Application : AuditableEntity
    {
        public string _name;
        public string Name
        {
            get => _name;
            private set => _name = value?.ToLowerInvariant();
        }
        public string Description { get; set; }

        public Version Version { get; set; }
        public ICollection<Permision> Permisions { get; set; }

        public Application(string name)
        {
            Name = name;
            Permisions = new List<Permision>();
        }
    }
}