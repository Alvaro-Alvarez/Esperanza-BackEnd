using System.Net;
using System.Text.Json;

namespace Esperanza.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HandleException");
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            HttpStatusCode status;
            string message;
            var stackTrace = String.Empty;

            var exceptionType = exception.GetType();
            //if (exceptionType == typeof(BadRequestException)) status = HttpStatusCode.BadRequest;
            //else if (exceptionType == typeof(AuthenticationException)) status = HttpStatusCode.Forbidden;
            //else status = HttpStatusCode.InternalServerError;
            status = HttpStatusCode.InternalServerError;
            if (env.IsEnvironment("Development"))
                stackTrace = exception.StackTrace;

            message = exception.Message;
            var result = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
