using Auth.Domain.Applications;
using System;

namespace Auth.Application.Attributtes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class Authorize : Attribute
    {
        public string Permission { get; private set; }
        public Authorize(string permision)
        {
            Permission = permision;
        }
    }
}
