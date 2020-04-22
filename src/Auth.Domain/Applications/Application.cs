using Auth.Domain;
using System.Collections.Generic;

namespace Auth.Domain.Applications
{
    public class Application
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        public Version Version { get; set; }
        public IEnumerable<Permision> Permisions { get; set; }
    }
}
