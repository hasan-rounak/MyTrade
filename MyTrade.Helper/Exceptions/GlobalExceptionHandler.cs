using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using MyTrade.Domain;
using System;
using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Hosting;


namespace MyTrade.Helper.Exceptions
{
    public static class GlobalExceptionHandler
    {
        /// <summary>
        ///     Logs unhandled exception and returns the HTTP status code and error object for the exception
        /// </summary>
        public static ApiErrorResponse HandleException(IExceptionHandlerPathFeature exceptionFeature, ILogger logger, bool isDevelopment)
        {
            return HandleException(exceptionFeature?.Error, exceptionFeature?.Path, logger, isDevelopment);
        }

        public static ApiErrorResponse HandleException(Exception exception, string path, ILogger logger, bool isDevelopment)
        {
            string errorId = Guid.NewGuid().ToString();

            // Fallback route in case the exception feature
            // or the contained Error object is null
            ApiErrorResponse apiErrorResponse = exception == null
                ? new ApiErrorResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Error = new ApiError
                    {
                        ErrorId = errorId,
                        Path = path
                    }
                }
                : new ApiErrorResponse
                {
                    StatusCode = TranslateExceptionToStatusCode(exception),
                    Error = new ApiError
                    {
                        ErrorId = errorId,
                        Path = path,
                        Type = exception.GetType().Name,
                        Message = exception.Message,
                        Exception = exception.ToString()
                    }
                };

            // Log whole exception object along with error id
            logger.LogError(exception, apiErrorResponse.ToString());

            // Clear exception object before sending out if not in development 
            if (!isDevelopment)
            {
                apiErrorResponse.Error.Exception = null;
            }

            return apiErrorResponse;
        }

        private static HttpStatusCode TranslateExceptionToStatusCode(Exception exception)
        {
            return exception switch
            {
                ArgumentNullException _ or ArgumentOutOfRangeException _ or ArgumentException _ => HttpStatusCode.BadRequest,
                NotImplementedException _ => HttpStatusCode.NotImplemented,
                AuthenticationException _ => HttpStatusCode.Unauthorized,
                UnauthorizedAccessException _ => HttpStatusCode.Forbidden,
                _ => HttpStatusCode.InternalServerError,
            };
        }
        //public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        //{
        //    IWebHostEnvironment environment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
        //    ILogger logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppBuilderExtensions");

        //    return app.UseExceptionHandler
        //    (
        //        errorApp => errorApp.Run
        //        (
        //            async context =>
        //            {
        //                IExceptionHandlerPathFeature exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        //                bool isDevelopment = environment.IsDevelopment() || environment.IsEnvironment("LocalMachine");
        //                ApiErrorResponse errorResponse = GlobalExceptionHandler.HandleException(exceptionFeature, logger, isDevelopment);

        //                context.Response.ContentType = "application/json";
        //                context.Response.StatusCode = (int)errorResponse.StatusCode;
        //                await context.Response.WriteAsync(errorResponse.ToString());
        //            }
        //        )
        //    );
        //}
    }
}
