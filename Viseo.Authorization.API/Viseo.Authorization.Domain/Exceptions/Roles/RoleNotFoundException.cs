using System;
using System.Collections.Generic;
using System.Text;

namespace Viseo.Authorization.Domain.Exceptions
{
    public class RoleNotFoundException : RoleException
    {
        public RoleNotFoundException(string message)
            :base(message)
        {

        }

        public RoleNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
