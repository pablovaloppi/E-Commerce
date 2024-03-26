using E_Commerce.Responses;
using E_Commerce.CustomExceptionMiddleware.CustomExceptions;
using Interfaces;
using System.Net;

namespace E_Commerce.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger ) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext) {
            try {
                await _next( httpContext );
            }
            catch( Exception ex ) { 
                _logger.LogError( $"Something went wrong: {ex}" );
                await HandleExceptionAsync( httpContext, ex );
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception ) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync( GetMessageException(exception).ToString());
        }

        private ErrorDetails GetMessageException(Exception exception ) {
           var errorDetails = new ErrorDetails();
            switch( exception ) {
                case ValidationException ex:
                    errorDetails = GenerateError( HttpStatusCode.BadRequest, "Ha occurido un error en la validacion de los datos" );
                    break;

                default:
                    errorDetails = GenerateError( HttpStatusCode.InternalServerError, "Interanl Server Error from the custom middleware." );
                    break;
            }
            return errorDetails;
        }
    
        private ErrorDetails GenerateError(HttpStatusCode statusCode, string message) {
            return new ErrorDetails() {
                StatusCode = (int)statusCode,
                Message = message
            };
        }
    }
}
