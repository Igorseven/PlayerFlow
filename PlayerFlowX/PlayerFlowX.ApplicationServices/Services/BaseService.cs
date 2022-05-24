using PlayerFlowX.Business.Extensions;
using PlayerFlowX.Business.Interfaces.OthersContracts;
using PlayerFlowX.Domain.Enums;
using System.Threading.Tasks;

namespace PlayerFlowX.ApplicationServices.Services
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        private readonly INotificationHandler _notification;
        private readonly IValidationHandler<TEntity> _validation;

        protected BaseService(INotificationHandler notification, IValidationHandler<TEntity> validation)
        {
            this._notification = notification;
            this._validation = validation;
        }

        public async Task<bool> ValidatedAsync(TEntity entity)
        {
            if (this._validation is null)
            {
                this._notification.AddNotification("Invalid", EMessage.ErrorNotConfigured.Description());
            }

            var response = await this._validation.ValidationAsync(entity);

            if (!response.Valid)
            {
                this._notification.AddNotifications(response.Errors);
            }

            return response.Valid;
        }
    }
}
