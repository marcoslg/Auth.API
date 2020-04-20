using System;

namespace Viseo.Authorization.Domain.Models
{
    public class Resource
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsDisabled { get; set; }
    }
}
