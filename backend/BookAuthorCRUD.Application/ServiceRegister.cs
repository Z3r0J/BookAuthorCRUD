using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Application.Services;
using MediatR.NotificationPublishers;
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
            config.NotificationPublisher = new TaskWhenAllPublisher();
            
        });

        services.AddScoped<IBookService, BookServices>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IGenreService, GenreService>();

        return services;
    }
}
