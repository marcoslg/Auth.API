using System;

namespace Viseo.Authorization.Domain.Exceptions.Users
{
    public class UserArgumentException : UserException
    {
        public UserArgumentException(string message)
            : base(message)
        {
        }

        public UserArgumentException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
