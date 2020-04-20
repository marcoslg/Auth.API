using System;
using System.Collections.Generic;
using System.Text;

namespace Viseo.Authorization.Domain.Exceptions
{
    public class RoleAlredyExistsException : RoleException
    {
        public RoleAlredyExistsException(string message)
            :base(message)
        {

        }

        public RoleAlredyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
