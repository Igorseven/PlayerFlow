using Microsoft.Extensions.DependencyInjection;
using PlayerFlowX.API.Filters;

namespace PlayerFlowX.API.Settings
{
    public static class FiltersConfiguration
    {
        public static void AddFiltersConfigurations(this IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.AddService<NotificationFilter>();
            });

            services.AddScoped<NotificationFilter>();
        }
    }
}
