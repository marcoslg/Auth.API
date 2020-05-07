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
        public const string RoleSearchrole = "role.searchrole";
        #endregion roles

        #region users
        public const string UserCreated = "user.created";
        public const string UserDisabled = "user.disabled";
        public const string UserEnabled = "user.enabled";
        public const string UserGet = "user.get";
        public const string UserSearchrole = "user.searchrole";
        #endregion users
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
                Permision.For(RoleSearchrole),
                #endregion roles

                #region users
                Permision.For(UserCreated),
                Permision.For(UserDisabled),
                Permision.For(UserEnabled),
                Permision.For(UserGet),
                Permision.For(UserSearchrole),
                #endregion users
            };
        }
    }
}
