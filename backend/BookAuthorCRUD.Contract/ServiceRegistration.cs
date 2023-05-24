using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookAuthorCRUD.Contract
{
    public static class ServiceRegistration
    {

        public static void AddContractServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly,ServiceLifetime.Scoped);
        }

    }
}