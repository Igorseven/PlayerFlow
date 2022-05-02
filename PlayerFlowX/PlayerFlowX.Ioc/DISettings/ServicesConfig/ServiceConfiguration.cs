using Microsoft.Extensions.DependencyInjection;
using PlayerFlowX.Business.Interfaces.OthersContracts;
using PlayerFlowX.Infra.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerFlowX.Ioc.DISettings.ServicesConfig
{
    public static class ServiceConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            //services.AddScoped<IPagingService<Game>, PagingService<Game>>();
        }
    }
}
