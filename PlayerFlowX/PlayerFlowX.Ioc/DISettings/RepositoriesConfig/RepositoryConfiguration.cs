using Microsoft.Extensions.DependencyInjection;
using PlayerFlowX.Business.Interfaces.RepositoryContract;
using PlayerFlowX.Infra.Repository;

namespace PlayerFlowX.Ioc.DISettings.RepositoriesConfig
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositoryCongiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
