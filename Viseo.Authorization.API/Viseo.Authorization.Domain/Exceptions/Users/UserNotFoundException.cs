using System;

namespace Viseo.Authorization.Domain.Exceptions.Users
{
    public class UserNotFoundException : UserException
    {
        public UserNotFoundException(string message)
            : base(message)
        {
        }

        public UserNotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
