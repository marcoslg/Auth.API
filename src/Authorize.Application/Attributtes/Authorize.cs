using Authorize.Domain.Applications;
using System;

namespace Authorize.Application.Attributtes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizeAttribute : Attribute
    {
        public string Permission { get; private set; }
        public AuthorizeAttribute(string permision)
        {
            Permission = permision;
        }
    }
}
