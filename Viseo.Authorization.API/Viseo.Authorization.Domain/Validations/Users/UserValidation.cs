using Birchman.Patterns.Notification;
using Viseo.Authorization.Domain.Models;

namespace Viseo.Authorization.Domain.Validations.Users
{
    internal static class UserValidation
    {
        public static Notification Validate(this User user)
        {
            var notification = new NotificationUser();
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                notification.AddError(new Error($"{nameof(user.UserName)} cannot be null or empty"));
            }
            
            return notification;
        }
        public static void Check(this User user)
        {
            var notification = user.Validate();
            notification.Check();
        }
    }
}
