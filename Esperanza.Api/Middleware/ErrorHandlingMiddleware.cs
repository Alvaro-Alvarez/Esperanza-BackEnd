using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Logs;
using Esperanza.Core.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Json;

namespace Esperanza.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Logs LogsSettings;
        private readonly IErrorsRepository ErrorsRepository;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(
            RequestDelegate next,
            ILogger<ErrorHandlingMiddleware> logger,
            IOptions<Logs> logsSettings,
            IErrorsRepository errorsRepository
            )
        {
            _next = next;
            _logger = logger;
            LogsSettings = logsSettings.Value;
            ErrorsRepository = errorsRepository;
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

        private Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            HttpStatusCode status;
            string message;
            string errId = string.Empty;
            var stackTrace = String.Empty;

            var exceptionType = exception.GetType();
            status = HttpStatusCode.InternalServerError;
            stackTrace = exception.StackTrace;

            message = exception.Message;
            var result = JsonSerializer.Serialize(new { error = message, stackTrace });
            try
            {
                errId = ErrorsRepository.InsertError(new Core.Models.Errors(message, stackTrace)).Result;
            }
            catch (Exception ex) { }

            Log.Error(LogsSettings.Path, result);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            //return context.Response.WriteAsync(result);
            return context.Response.WriteAsync(string.IsNullOrEmpty(errId) ? "Ocurrió un error inesperado." : $"Ocurrió un error inesperado. El código del error es '{errId}'");
        }
    }
}
