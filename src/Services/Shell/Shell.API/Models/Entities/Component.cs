namespace Shell.API.Models.Entities
{
    public class Component
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string RemoteName { get; set; }
        public string RemoteEndpoint { get; set; }
        public string ComponentName { get; set; }
        public bool RequireAuthentication { get; set; }
    }
}
