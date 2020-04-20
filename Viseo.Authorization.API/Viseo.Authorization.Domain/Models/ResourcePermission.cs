using System;
using System.Collections.Generic;
using System.Text;
using Viseo.Authorization.Domain.Models.Enum;

namespace Viseo.Authorization.Domain.Models
{
    public class ResourcePermission
    {        
        public Dictionary<string, Permision> Permisions { get; set; }

        public static ResourcePermission operator +(ResourcePermission x, ResourcePermission y)
        {
            var result = new Dictionary<string, Permision>();
            foreach (var item in x.Permisions)
            {
                var value = item.Value;
                if (y.Permisions.ContainsKey(item.Key))
                {
                    value |= y.Permisions[item.Key];
                }
                result.Add(item.Key, value);
            }
            return new ResourcePermission() { Permisions = result };
        }
    }
}
