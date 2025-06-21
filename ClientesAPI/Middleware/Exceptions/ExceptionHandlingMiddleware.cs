using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace ClientesAPI.Middleware.Exceptions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string? stackTrace = null;
            string message = ex.Message;
            var exceptionType = ex.GetType();

            //if(exceptionType == typeof()) {}

            var response = JsonSerializer.Serialize(new { statusCode, message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 401;
            return context.Response.WriteAsync(response);
        }
    }
}
