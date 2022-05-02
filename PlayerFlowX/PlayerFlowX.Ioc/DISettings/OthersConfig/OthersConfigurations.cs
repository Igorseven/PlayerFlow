using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlayerFlowX.ApplicationServices.AutoMapperSettings;
using PlayerFlowX.Business.Handlers.NotificationHandlers;
using PlayerFlowX.Business.Interfaces.OthersContracts;

namespace PlayerFlowX.Ioc.DISettings.OthersConfig
{
    public static class OthersConfigurations
    {
        public static void AddOthersConfigurations(this IServiceCollection services, IConfiguration configuration = null)
        {
            AutoMapperConfigurations.Inicialize();

            services.AddScoped<INotificationHandler, NotificationHandler>();
        }
    }
}
