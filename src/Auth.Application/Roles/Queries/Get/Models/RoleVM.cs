namespace Auth.Application.Roles.Queries.Get.Models
{
    public class RoleVM
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public RoleVM(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
