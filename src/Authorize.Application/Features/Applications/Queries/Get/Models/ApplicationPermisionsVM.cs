using Authorize.Application.Features.Applications.Queries.Models;
using System.Collections.Generic;

namespace Authorize.Application.Features.Applications.Queries.Get.Models
{
    public class ApplicationPermissionsVM : ApplicationVM
    {
        public ApplicationPermissionsVM(string name, string description, bool isEnabled,
            IDictionary<string, IEnumerable<string>> permissions)
            : base(name, description, isEnabled)
        {
            Permissions = permissions ?? new Dictionary<string, IEnumerable<string>>();
        }

        public IDictionary<string, IEnumerable<string>> Permissions { get; set; }

    }
}