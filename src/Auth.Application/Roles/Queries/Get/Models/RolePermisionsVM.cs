using Auth.Application.Roles.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Application.Roles.Queries.Get.Models
{
    public class RolePermisionsVM : RoleVM
    {
        public RolePermisionsVM(string name, string description, IDictionary<string, IEnumerable<string>> permisions)
            : base(name, description)
        {
            Permisions = permisions ?? new Dictionary<string, IEnumerable<string>>();
        }

        public IDictionary<string, IEnumerable<string>> Permisions { get; set; }


    }
}
