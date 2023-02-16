namespace Shell.API.Models.DTOs
{
    public class Component : ComponentBase
    {
      
        public string RemoteName { get; set; }
        public string RemoteEndpoint { get; set; }
        public string ComponentName { get; set; }
        public bool RequireAuthentication { get; set; }
    }
}
