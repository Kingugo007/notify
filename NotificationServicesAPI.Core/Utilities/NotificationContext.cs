using Microsoft.Extensions.Configuration;

namespace NotificationServicesAPI.Core.Utilities
{
    public class NotificationContext
    {
        public string Address { get; set; } = string.Empty;
        public string Header { get; set; } = string.Empty;
        public string Payload { get; set; } = null!;    
        public IConfiguration Config { get; set; } = null!;
    }
}
