using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlayerFlowX.Business.Handlers.NotificationHandlers;
using PlayerFlowX.Business.Interfaces.OthersContracts;

namespace PlayerFlowX.Ioc.DISettings.OthersConfig
{
    public static class OthersConfigurations
    {
        public static void AddOthersConfigurations(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddScoped<INotificationHandler, NotificationHandler>();
        }
    }
}
