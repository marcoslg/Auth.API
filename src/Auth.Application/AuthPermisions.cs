using Auth.Domain.Applications;
using System.Collections.Generic;

namespace Auth.Application
{
    public interface IAuthPermisions
    {
        IEnumerable<Permision> Permissions { get; }
    }
    public class AuthPermisions : IAuthPermisions
    {
        #region roles
        public const string RoleCreated = "role.created";
        public const string RoleDisabled = "role.disabled";
        public const string RoleEnabled = "role.enabled";
        public const string RoleGet = "role.get";
        public const string RoleSearch = "role.searchrole";
        #endregion roles

        #region users
        public const string UserCreated = "user.created";
        public const string UserDisabled = "user.disabled";
        public const string UserEnabled = "user.enabled";
        public const string UserGet = "user.get";
        public const string UserSearch = "user.searchrole";
        #endregion users

        #region applications
        public const string ApplicationCreated = "application.created";
        public const string ApplicationDisabled = "application.disabled";
        public const string ApplicationEnabled = "application.enabled";
        public const string ApplicationGet = "application.get";
        public const string ApplicationSearch = "application.searchrole";
        #endregion applications


        public IEnumerable<Permision> Permissions { get; private set; }

        public AuthPermisions()
        {
            Permissions = new List<Permision>()
            {
                #region roles
                Permision.For(RoleCreated),
                Permision.For(RoleDisabled),
                Permision.For(RoleEnabled),
                Permision.For(RoleGet),
                Permision.For(RoleSearch),
                #endregion roles

                #region users
                Permision.For(UserCreated),
                Permision.For(UserDisabled),
                Permision.For(UserEnabled),
                Permision.For(UserGet),
                Permision.For(UserSearch),
                #endregion users

                #region applications
                Permision.For(ApplicationCreated),
                Permision.For(ApplicationDisabled),
                Permision.For(ApplicationEnabled),
                Permision.For(ApplicationGet),
                Permision.For(ApplicationSearch),
                #endregion applications
            };
        }
    }
}