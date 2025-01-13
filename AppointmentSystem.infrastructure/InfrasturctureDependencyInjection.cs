using AppointmentSystem.Core.Interfaces;
using AppointmentSystem.Core.Options;
using AppointmentSystem.infrastructure.Data;
using AppointmentSystem.infrastructure.Repositories;
using AppointmentSystem.infrastructure.Repositories.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AppointmentSystem.infrastructure
{
    public static class InfrasturctureDependencyInjection
    {
        public static IServiceCollection AddInfrasturctureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, option) =>
            {
                option.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<DatabaseConfigurationOptions>>().Value.DefaultConnection);
            });
            services.AddScoped<IUserRepository, UserReporsitory>();
            services.AddScoped<ILoginPageLocalizationRepository, LoginPageLocalizationRepository>();
            return services;
        }
    }
}
