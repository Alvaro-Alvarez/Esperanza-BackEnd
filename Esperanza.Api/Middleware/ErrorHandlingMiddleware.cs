using Esperanza.Core.Enums;
using Esperanza.Core.Exceptions;
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
            string message = string.Empty;
            string result = string.Empty;
            bool controlledError = false;
            string errId = string.Empty;

            var exceptionType = exception.GetType();
            status = HttpStatusCode.InternalServerError;

            if (exceptionType == typeof(BusinessException))
            {
                controlledError = true;
                var errorCode = exception.GetType().GetProperty("ErrorCode").GetValue(exception, null);
                status = HttpStatusCode.BadRequest;
                switch (errorCode)
                {
                    case ErrorCode.InvalidPassword: message = "Contraseña incorrecta";
                        break;
                    case ErrorCode.InvalidReCaptcha: message = "Recaptcha inválido";
                        break;
                    case ErrorCode.UserNotFound: message = "Usuario inexistente";
                        break;
                    case ErrorCode.InvalidCodeRecovery: message = "Código de verificación incorrecto";
                        break;
                    case ErrorCode.ClientCodeFound: message = "El código de cliente ya está en uso";
                        break;
                    case ErrorCode.ClientCodeNotFound: message = "Código de cuit o numero de cliente incorrecto";
                        break;
                    case ErrorCode.InvalidCuit: message = "Código de cuit o numero de cliente incorrecto";
                        break;
                }
            }
            if (!controlledError)
            {
                message = exception.Message;
                result = JsonSerializer.Serialize(new { error = message, exception.StackTrace });
                try
                {
                    errId = ErrorsRepository.InsertError(new Core.Models.Errors(message, exception.StackTrace)).Result;
                }
                catch (Exception ex) { }
            }

            Log.Error(result);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            var msg = controlledError ? message : (string.IsNullOrEmpty(errId) ? "Ocurrió un error inesperado." : $"Ocurrió un error inesperado. El código del error es '{errId}'");
            return context.Response.WriteAsync(msg);
        }
    }
}
