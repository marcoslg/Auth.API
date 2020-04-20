using System;
using System.Collections.Generic;
using System.Text;

namespace Viseo.Authorization.Domain.Models
{
    public class ResourceRolePermision : Role
    {        
        public Resource Resource {get;set;}
        public ResourcePermission ResourcePermission { get; set; }
        public Version Version { get; set; }
    }
}
