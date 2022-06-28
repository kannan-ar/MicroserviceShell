using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Shell.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "text/plain";
            context.Response.StatusCode = (int)(ex switch
            {
                BadHttpRequestException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            });

            return context.Response.WriteAsync("There is an error occured. Please try again!");
        }
    }
}
