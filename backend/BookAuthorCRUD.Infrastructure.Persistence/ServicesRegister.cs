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

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
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
                            configuration.GetConnectionString("DefaultConnection"),
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
