using BookAuthorCRUD.Domain.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookAuthorCRUD.API.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) =>
            _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string errorId = Guid.NewGuid().ToString();

            var result = new ExceptionResult
            {
                ErrorId = errorId,
                Message = exception.Message,
                Source = exception.Source,
                SupportMessage =
                    $"Provide the error id {errorId} to the support team for further analysis"
            };

            if (exception is not NotFoundException && exception.InnerException != null)
            {
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }
            }

            result.StatusCode = exception switch
            {
                NotFoundException x => (int)x.StatusCode,
                _ => (int)StatusCodes.Status500InternalServerError
            };

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = result.StatusCode;

            _logger.LogError(exception, exception.Message);

            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
