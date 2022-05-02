using PlayerFlowX.Business.Interfaces.OthersContracts;
using System.Collections.Generic;
using System.Linq;

namespace PlayerFlowX.Business.Handlers.NotificationHandlers
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly List<DomainNotification> _notifications;

        public NotificationHandler()
        {
            this._notifications = new List<DomainNotification>();
        }

        public bool HasNotification() => this._notifications.Any();

        public List<DomainNotification> GetNotifications() => this._notifications;

        public void AddNotification(DomainNotification notification)
        {
            this._notifications.Add(notification);
        }

        public void AddNotification(string key, string value)
        {
            this._notifications.Add(new DomainNotification(key, value));
        }

        public void AddNotifications(IEnumerable<DomainNotification> notificationList)
        {
           this._notifications.AddRange(notificationList);
        }

        public void AddNotifications(Dictionary<string, string> notifications)
        {
            foreach (var notification in notifications)
            {
                AddNotification(notification.Key, notification.Value);
            }
        }
    }
}
