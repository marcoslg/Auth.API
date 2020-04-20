using System;
using System.Collections.Generic;
using System.Text;

namespace Viseo.Authorization.Domain.Exceptions
{
    public class RoleException : Exception
    {
        public RoleException(string message)
            :base(message)
        {

        }

        public RoleException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
