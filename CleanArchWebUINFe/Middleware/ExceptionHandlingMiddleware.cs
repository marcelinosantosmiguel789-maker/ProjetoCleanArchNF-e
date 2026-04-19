using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using CleanArchNF_eDomain.Validation;

namespace CleanArchWebUINFe.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Ocorreu um erro inesperado.";

            if (exception is NFeExceptionValidation)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                message = exception.Message;
            }
            else if (exception is KeyNotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
                message = exception.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var result = JsonSerializer.Serialize(new { error = message });
            return context.Response.WriteAsync(result);
        }
    }
}
