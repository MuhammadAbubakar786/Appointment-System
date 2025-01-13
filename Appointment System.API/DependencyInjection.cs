using AppointmentSystem.Application;
using AppointmentSystem.Core;
using AppointmentSystem.infrastructure;

namespace Appointment_System.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI().AddInfrasturctureDI().AddCoreDI(configuration);
            return services;
        }
    }
}
