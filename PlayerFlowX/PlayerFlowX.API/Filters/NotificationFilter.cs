using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayerFlowX.Business.Interfaces.OthersContracts;

namespace PlayerFlowX.API.Filters
{
    public class NotificationFilter : ActionFilterAttribute
    {
        private readonly INotificationHandler _notificationHandler;

        public NotificationFilter(INotificationHandler notification)
        {
            this._notificationHandler = notification;
        }

        public override void OnActionExecuted(ActionExecutedContext actionContext)
        {
            if (this._notificationHandler.HasNotification())
            {
                actionContext.Result = new BadRequestObjectResult(this._notificationHandler.GetNotifications());
            }

            base.OnActionExecuted(actionContext);
        }
    }
}
