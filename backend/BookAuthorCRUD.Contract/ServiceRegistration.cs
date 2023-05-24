using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookAuthorCRUD.Contract
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddContractServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(),ServiceLifetime.Scoped);

            return services;
        }

    }
}