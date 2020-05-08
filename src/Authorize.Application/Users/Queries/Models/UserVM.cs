namespace Authorize.Application.Users.Queries.Models
{
    public class UserVM
    {
        public string UserName { get; private set; }
        public bool IsEnabled { get; private set; }

        public UserVM(string name, bool isEnabled)
        {
            UserName = name;
            IsEnabled = isEnabled;
        }
    }
}
