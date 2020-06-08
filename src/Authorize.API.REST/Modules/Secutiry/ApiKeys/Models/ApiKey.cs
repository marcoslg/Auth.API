using System;

namespace Authorize.API.REST.Modules.Secutiry.ApiKeys.Models
{
    public class ApiKey
    {
        public ApiKey(int id, string owner, string key, DateTime created)//, IReadOnlyCollection<string> permissions)
        {
            Id = id;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Created = created;
            //Permissions = permissions ?? throw new ArgumentNullException(nameof(permissions));
        }

        public int Id { get; }
        public string Owner { get; }
        public string Key { get; }
        public DateTime Created { get; }
        //public IReadOnlyCollection<string> Permissions { get; }
    }

}
