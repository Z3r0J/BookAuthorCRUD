using BookAuthorCRUD.Application;
using Microsoft.Extensions.DependencyInjection;
using BookAuthorCRUD.Contract;
using BookAuthorCRUD.Infrastructure.Persistence.Repository;
using BookAuthorCRUD.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookAuthorCRUD.Test
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.Services.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug);
            });
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        { "UseInMemoryDatabase", "true" }
                    }!
                )
                .Build();
            services.AddPersistence(configuration);
            services.AddRepositories();
            services.AddContractServices();
            services.AddApplicationServices();

            var serviceProvider = new DefaultServiceProviderFactory();

            return serviceProvider.CreateServiceProvider(services);
        }
    }
}
