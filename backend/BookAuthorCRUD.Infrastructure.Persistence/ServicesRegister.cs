﻿using BookAuthorCRUD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookAuthorCRUD.Infrastructure.Persistence
{
    public static class ServicesRegister
    {
        public static void AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            #region Database Configuration

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
                services.AddDbContext<ApplicationContext>(
                    opt => opt.UseInMemoryDatabase("BookAuthorMemoryDatabase")
                );

            services.AddDbContext<ApplicationContext>(
                opt =>
                    opt.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)
                    )
            );

            #endregion
        }
    }
}
