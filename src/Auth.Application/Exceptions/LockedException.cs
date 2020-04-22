using System;

namespace Auth.Application.Exceptions
{
    public class LockedException : Exception
    {
        public LockedException()
            : base()
        {
        }

        public LockedException(string message)
            : base(message)
        {
        }

        public LockedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LockedException(string name, object key)
            : base($"Entity \"{name}\" ({key}) had locked.")
        {
        }
    }
}
