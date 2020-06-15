using Authorize.Application.Features.Applications.Queries.Get.Models;
using System.Collections.Generic;
using System.Linq;

namespace Authorize.Application.Features.Applications.Queries.Get
{
    internal static class ApplicationMapper
    {
        public static ApplicationPermissionsVM ToMap(this Domain.Applications.Application application)
        {
            var permissions = new Dictionary<string, IEnumerable<string>>();
            permissions.Add(application.Name, application.Permissions.Select(p => p.Name));
            return new ApplicationPermissionsVM(application.Name, application.Description, application.IsEnabled, permissions);
        }

        public static IQueryable<ApplicationPermissionsVM> ToMap(this IQueryable<Domain.Applications.Application> applicationQuery)
            => applicationQuery.Select(x => x.ToMap());
    }
}