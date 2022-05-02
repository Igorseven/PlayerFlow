using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace PlayerFlowX.ApplicationServices.AutoMapperSettings
{
    public static class AutoMapperConfigurations
    {
        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration Configuration { get; private set; }

        public static void Inicialize()
        {
            Configuration = new MapperConfiguration(config =>
            {
                var profiles = Assembly.GetExecutingAssembly()
                .GetExportedTypes().Where(p => p.IsClass && typeof(Profile).IsAssignableFrom(p));

                foreach (var profile in profiles)
                {
                    config.AddProfile((Profile)Activator.CreateInstance(profile));
                }
            });

            Mapper = Configuration.CreateMapper();
        }
    }
}
