using Birchman.Patterns.Notification;
using System;

namespace Viseo.Authorization.Domain.Validations.Roles
{
    internal static class RoleValidations
    {
        public static Notification Validate(this Role role)
        {
            var notification = new NotificationRole();
            if (string.IsNullOrWhiteSpace(role.Name))
            {
                notification.AddError(new Error($"{nameof(role.Name)} cannot be null or empty"));
            }
            if (role.Created > DateTime.UtcNow)
            {
                notification.AddInformation(new Information($"{nameof(role.Name)}: {role.Name} is great current date"));
            }
            if (role.Expired.HasValue && role.Expired.Value > role.Created)
            {
                notification.AddError(new Error($"{nameof(role.Expired)}: {role.Expired} is great {nameof(role.Created)}: {role.Created}"));
            }
            return notification;
        }
        public static void Check(this Role role)
        {
            var notification = role.Validate();
            notification.Check();
        }
    }
}
