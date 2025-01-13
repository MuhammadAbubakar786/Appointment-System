using AppointmentSystem.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSystem.Core
{
    public static class CoreDependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseConfigurationOptions>(configuration.GetSection(DatabaseConfigurationOptions.SectionName));
            return services;
        }
    }
}
