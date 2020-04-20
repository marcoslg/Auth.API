using System;

namespace Viseo.Authorization.Domain
{
    public class Role
    {
        private bool _isDisabled;
        public string Name { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Expired { get; set; }
        public bool IsDisabled {
            get
            {
                if (!_isDisabled && Expired.HasValue)
                {
                    return Expired.Value < DateTime.UtcNow;
                }
                return _isDisabled;
            }
            set => _isDisabled = value; }

        public Role()
        {

        }
        public Role(string name)
        {
            Name = name;
        }
    }
}
