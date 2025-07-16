using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Inovola.Application
{
    public static class Configure
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(option => {
                option.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;

        }
    }
}
