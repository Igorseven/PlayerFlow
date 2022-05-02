using Microsoft.Extensions.DependencyInjection;

namespace PlayerFlowX.API.Settings
{
    public static class CorsConfiguration
    {

        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(config =>
            {
                config.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
            });
        }
    }
}
