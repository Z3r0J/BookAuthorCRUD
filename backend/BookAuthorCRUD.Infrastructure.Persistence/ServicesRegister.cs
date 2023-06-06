using BookAuthorCRUD.Domain.Interfaces;
using BookAuthorCRUD.Infrastructure.Persistence.Contexts;
using BookAuthorCRUD.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookAuthorCRUD.Infrastructure.Persistence
{
    public static class ServicesRegister
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            #region Database Configuration

            bool? useInMemoryEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_USEINMEMORY")?.ToLower() switch
            {
                "true" => true,
                "false" => false,
                _ => null
            };

            if (useInMemoryEnvironment ?? configuration.GetValue<bool>("UseInMemoryDatabase"))
            {

                services.AddDbContext<ApplicationContext>(
                    opt => opt.UseInMemoryDatabase("BookAuthorMemoryDatabase")
                );
            }
            else
            {
                services.AddDbContext<ApplicationContext>(
                    opt =>
                        opt.UseSqlServer(
                            Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING") ?? configuration.GetConnectionString("DefaultConnection"),
                            m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)
                        )
                );
            }

            #endregion

            #region Unit Of Work

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            #endregion

            return services;

        }
    }
}
