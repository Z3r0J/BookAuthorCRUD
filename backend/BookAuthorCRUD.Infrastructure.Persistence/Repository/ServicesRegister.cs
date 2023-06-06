using BookAuthorCRUD.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookAuthorCRUD.Infrastructure.Persistence.Repository
{
    public static class ServicesRegister
    {

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenreRepository,GenreRepository>();
            services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
        }

    }
}
