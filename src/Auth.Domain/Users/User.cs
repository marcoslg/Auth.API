using Microsoft.AspNetCore.Identity;

namespace Auth.Domain.Users
{
    public class User : IdentityUser<string>
    {

        public override string Id
        {
            get => UserName;
            set => UserName = value;
        }
    }
}
