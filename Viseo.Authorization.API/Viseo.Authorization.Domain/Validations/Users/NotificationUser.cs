using Birchman.Patterns.Notification;
using Viseo.Authorization.Domain.Exceptions.Users;

namespace Viseo.Authorization.Domain.Validations.Users
{
    internal class NotificationUser : Notification
    {
        public override void ThrowsException()
            => throw new UserException(GetErrorReport());
    }
}
