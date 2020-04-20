using System;
using System.Collections.Generic;
using System.Text;

namespace Viseo.Authorization.Domain.Models.Roles
{
    public class Group : Role
    {
        public IDictionary<string, IEnumerable<ResourceRolePermision>> Roles { get; set; }
    }
}
