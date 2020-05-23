using Authorize.Application.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Authorize.Front.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "admin";
        }

        public string UserName { get; }
    }
}
