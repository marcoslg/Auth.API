﻿using Auth.Application.Roles.Queries.Models;
using System.Collections.Generic;

namespace Auth.Application.Roles.Queries.Get.Models
{
    public class RolePermisionsVM : RoleVM
    {
        public RolePermisionsVM(string name, string description, bool isEnabled, IDictionary<string, IEnumerable<string>> permisions)
            : base(name, description, isEnabled)
        {
            Permisions = permisions ?? new Dictionary<string, IEnumerable<string>>();
        }

        public IDictionary<string, IEnumerable<string>> Permisions { get; set; }


    }
}
