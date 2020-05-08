namespace Authorize.Application.Roles.Queries.Models
{
    public class RoleVM
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsEnabled { get; private set; }

        public RoleVM(string name, string description, bool isEnabled)
        {
            Name = name;
            Description = description;
            IsEnabled = isEnabled;
        }
    }
}
