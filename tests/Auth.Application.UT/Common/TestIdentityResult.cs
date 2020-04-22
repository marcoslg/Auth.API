using Microsoft.AspNetCore.Identity;

namespace Auth.Application.UT.Common
{
    internal class TestIdentityResult : IdentityResult
    {
        public TestIdentityResult(bool succeeded)
        {
            base.Succeeded = succeeded;
        }
    }
}
