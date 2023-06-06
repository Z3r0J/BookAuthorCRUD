using BookAuthorCRUD.API.Middlewares;
using BookAuthorCRUD.Application;
using BookAuthorCRUD.Contract;
using BookAuthorCRUD.Infrastructure.Persistence;
using BookAuthorCRUD.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddPersistence(builder.Configuration);
        builder.Services.AddRepositories();
        builder.Services.AddContractServices();
        builder.Services.AddApplicationServices();
        builder.Services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });

        builder.Services.AddTransient<ExceptionHandlingMiddleware>();

        builder.Services.AddCors(
            x => x.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
        );
        ;

        var app = builder.Build();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseCors();
        app.MapControllers();

        app.Run();

    }

}