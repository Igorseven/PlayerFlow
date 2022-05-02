using Microsoft.Extensions.DependencyInjection;
using PlayerFlowX.Business.Handlers.ValidationHandlers.EntitiesValidation;
using PlayerFlowX.Business.Interfaces.OthersContracts;
using PlayerFlowX.Domain.Entities;

namespace PlayerFlowX.Ioc.DISettings.ValidationsConfig
{
    public static class ValidationConfiguration
    {
        public static void AddValidationConfiguration(this IServiceCollection services )
        {
            services.AddScoped<IValidationHandler<Client>, ClientValidation>();
            services.AddScoped<IValidationHandler<Address>, AddressValidation>();
        }
    }
}
