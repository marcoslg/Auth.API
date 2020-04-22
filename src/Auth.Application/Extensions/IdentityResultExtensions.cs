using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace Auth.Application.Extensions
{
    internal static class IdentityResultExtensions
    {
        public static void ThrowIfError(this IdentityResult result)
        {
            if (!result.Succeeded)
            {
                var errorsStr = result.Errors.Select(e => $"{e.Code}: {e.Description}");
                throw new Exception(string.Join(";", errorsStr));
            }
        }

    }
}
