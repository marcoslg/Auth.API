using Auth.Domain.Common;
using System.Collections.Generic;

namespace Auth.Domain.Applications
{
    public class Permision : ValueObject
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private Permision() { }
        private Permision(string name, string description) 
        {
            Name = name;
            Description = description;
        }


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
