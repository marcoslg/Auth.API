using Auth.Application.Applications.Queries.Get.Models;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Application.Applications.Queries.Get
{
    internal static class ApplicationMapper
    {
        public static ApplicationPermisionsVM ToMap(this Domain.Applications.Application application)
        {
            var permisions = new Dictionary<string, IEnumerable<string>>();
            permisions.Add(application.Name, application.Permisions.Select(p => p.Name));
            return new ApplicationPermisionsVM(application.Name, application.Description, application.IsEnabled, permisions);
        }        

        public static IQueryable<ApplicationPermisionsVM> ToMap(this IQueryable<Domain.Applications.Application> applicationQuery)
            => applicationQuery.Select(x => x.ToMap());
    }
}