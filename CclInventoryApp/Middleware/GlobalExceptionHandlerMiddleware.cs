using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using CclInventoryApp.Exceptions;

namespace CclInventoryApp.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is AppException appException)
            {
                context.Response.StatusCode = appException.StatusCode;
                var response = new
                {
                    error = new
                    {
                        message = appException.Message,
                        code = appException.StatusCode
                    }
                };

                return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var defaultResponse = new
            {
                error = new
                {
                    message = "An unexpected error occurred.",
                    details = exception.Message,
                    code = context.Response.StatusCode
                }
            };

            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(defaultResponse));
        }
    }
}
