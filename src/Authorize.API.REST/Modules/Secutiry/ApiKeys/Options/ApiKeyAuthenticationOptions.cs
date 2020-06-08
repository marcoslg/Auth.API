using Microsoft.AspNetCore.Authentication;

namespace Authorize.API.REST.Modules.Secutiry.ApiKeys.Options
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "API Key";
        public string Scheme => DefaultScheme;
        public string AuthenticationType = DefaultScheme;
    }

}
