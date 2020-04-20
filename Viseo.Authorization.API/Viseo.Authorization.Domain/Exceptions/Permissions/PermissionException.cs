using System;
using System.Collections.Generic;
using System.Text;

namespace Viseo.Authorization.Domain.Exceptions.Permissions
{
    public class PermissionException : Exception
    {
        public PermissionException(string message)
            : base(message)
        {

        }

        public PermissionException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
