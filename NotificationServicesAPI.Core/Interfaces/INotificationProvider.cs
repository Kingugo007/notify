using NotificationServicesAPI.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationServicesAPI.Core.Interfaces
{
    public interface INotificationProvider
    {
        Task<bool> SendAsync(NotificationContext context);
    }
}
