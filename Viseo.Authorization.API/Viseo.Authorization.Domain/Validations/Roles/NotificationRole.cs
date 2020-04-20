using Birchman.Patterns.Notification;
using Viseo.Authorization.Domain.Exceptions;

namespace Viseo.Authorization.Domain.Validations.Roles
{
    internal class NotificationRole : Notification
    {
        public override void ThrowsException()
            => throw new RoleException(GetErrorReport());
    }
}
