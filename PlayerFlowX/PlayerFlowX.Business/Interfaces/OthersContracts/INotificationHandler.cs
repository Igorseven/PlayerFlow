using PlayerFlowX.Business.Handlers.NotificationHandlers;
using System.Collections.Generic;

namespace PlayerFlowX.Business.Interfaces.OthersContracts
{
    public interface INotificationHandler
    {
        List<DomainNotification> GetNotifications();
        bool HasNotification();
        void AddNotification(DomainNotification notification);
        void AddNotification(string key, string value);
        void AddNotifications(IEnumerable<DomainNotification> notificationList);
        void AddNotifications(Dictionary<string, string> notifications);
    }
}
