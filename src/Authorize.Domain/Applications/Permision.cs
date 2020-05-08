using Authorize.Domain.Common;
using System.Collections.Generic;

namespace Authorize.Domain.Applications
{
    public class Permision : ValueObject
    {
        public string _name;
        public string Name
        {
            get => _name;
            private set => _name = value?.ToLowerInvariant();
        }
        public string Description { get; private set; }

        private Permision(string name) {
            Name = name;
        }
        private Permision(string name, string description) 
        {
            Name = name;
            Description = description;
        }
        public static Permision For(string name)
        => new Permision(name);
        public static Permision For(string name, string description)
        => new Permision(name, description);

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? base.GetHashCode();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Description;
        }
    }
}
