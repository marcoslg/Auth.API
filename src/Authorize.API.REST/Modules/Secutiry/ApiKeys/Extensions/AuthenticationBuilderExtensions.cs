using Authorize.API.REST.Handlers;
using Authorize.API.REST.Modules.Secutiry.ApiKeys.Options;
using Microsoft.AspNetCore.Authentication;
using System;

namespace Authorize.API.REST.Modules.Secutiry.ApiKeys.Extensions
{
    public static class AuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddApiKeySupport(this AuthenticationBuilder authenticationBuilder, Action<ApiKeyAuthenticationOptions> options)
        {
            return authenticationBuilder.AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme, options);
        }
    }

}
