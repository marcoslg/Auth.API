namespace Auth.Domain.Applications
{
    public class Permision
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? base.GetHashCode();
        }
    }
}
