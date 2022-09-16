using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NotificationServices.Domain.Enums;
using NotificationServicesAPI.Core.Interfaces;
using NotificationServicesAPI.Core.Utilities;

namespace NotificationServices.Infrastructure.ExternalServices
{
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration _configuration;
        public readonly ILogger<NotificationService> _logger;

        private readonly Dictionary<NotificationType, INotificationProvider> _notificationProviders = new();

        public NotificationService(ILogger<NotificationService> logger, IConfiguration configuration)

        {
            _configuration = configuration;
            _logger = logger;
            // Register Providers            
            // _notificationProviders.Add(NotifyWith.Email, new SendGridEmailProvider()); 
        }
        public async Task<bool> SendAsync(NotificationType target, NotificationContext payload)
        {
            //Inject DI instances, cos different providers might use different Instances.                       
            payload.Config = _configuration;

            try
            {
                _ = !target.HasFlag(NotificationType.Email) ||
                    await _notificationProviders[NotificationType.Email].SendAsync(payload);
            }
            catch (Exception)
            {
                _logger.LogError($"notification Error: {target} => {payload.Header}");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
