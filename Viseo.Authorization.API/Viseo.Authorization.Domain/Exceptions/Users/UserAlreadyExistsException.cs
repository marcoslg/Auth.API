using System;

namespace Viseo.Authorization.Domain.Exceptions.Users
{
    public class UserAlreadyExistsException : UserException
    {
        public UserAlreadyExistsException(string message)
            : base(message)
        {
        }

        public UserAlreadyExistsException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
