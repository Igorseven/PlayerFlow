using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlayerFlowX.Infra.EFCore.Context;
using PlayerFlowX.Ioc.DISettings.OthersConfig;
using PlayerFlowX.Ioc.DISettings.RepositoriesConfig;
using PlayerFlowX.Ioc.DISettings.ServicesConfig;
using PlayerFlowX.Ioc.DISettings.ValidationsConfig;

namespace PlayerFlowX.Ioc.DISettings
{
    public static class HandlerConfiguration
    {
        public static void SettingDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityConfiguration(configuration);
            services.AddOthersConfigurations();
            services.AddValidationConfiguration();
            services.AddServicesConfiguration();
            services.AddRepositoryCongiguration();
        }
    }
}
