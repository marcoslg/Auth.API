using Authorize.Application.Applications.Queries.Models;
using System.Collections.Generic;

namespace Authorize.Application.Applications.Queries.Get.Models
{
    public class ApplicationPermisionsVM : ApplicationVM
    {
        public ApplicationPermisionsVM(string name, string description, bool isEnabled, IDictionary<string, IEnumerable<string>> permisions)
            : base(name, description, isEnabled)
        {
            Permisions = permisions ?? new Dictionary<string, IEnumerable<string>>();
        }

        public IDictionary<string, IEnumerable<string>> Permisions { get; set; }

    }
}