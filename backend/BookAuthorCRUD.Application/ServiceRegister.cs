using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookAuthorCRUD.Application;

public static class ServiceRegister
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining(typeof(ServiceRegister));
            
        });

        services.AddScoped<IBookService, BookServices>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IGenreService, GenreService>();

        return services;
    }
}
