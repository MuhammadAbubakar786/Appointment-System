using AppointmentSystem.Application.Behaviour;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AppointmentSystem.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(ApplicationDependencyInjection).Assembly));
            services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
