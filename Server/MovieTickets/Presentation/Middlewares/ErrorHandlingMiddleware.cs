using Common.Models;
using Microsoft.Extensions.Localization;
using Serilog;
using Newtonsoft.Json;
using System.Net;

namespace Presentation.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IStringLocalizer<ErrorHandlingMiddleware> _localizer;

        public ErrorHandlingMiddleware(RequestDelegate next, IStringLocalizer<ErrorHandlingMiddleware> localizer)
        {
            _next = next;
            _localizer = localizer;
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var errorResponse = new ResponseModel<object>
            {
                Success = false,
                Data = null
            };

            switch (exception)
            {
                case ArgumentNullException _:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = _localizer["ArgumentNullError"].Value;
                    break;
                case UnauthorizedAccessException _:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    errorResponse.Message = _localizer["UnauthorizedError"].Value;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = _localizer["InternalServerError"].Value;
                    break;
            }

            Log.Error(exception, "Error occurred: {Message}", exception.Message);
            var result = JsonConvert.SerializeObject(errorResponse);
            await response.WriteAsync(result);
        }
    }
}
