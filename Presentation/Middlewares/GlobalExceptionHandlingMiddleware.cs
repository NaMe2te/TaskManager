using System.Net;
using Presentation.Models;

namespace Presentation.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var error = exception switch
        {
            ArgumentNullException e => new ExceptionModel((int) HttpStatusCode.BadRequest, e.Message),
            _ => new ExceptionModel((int) HttpStatusCode.InternalServerError, exception.Message)
        };

        context.Response.StatusCode = error.Code;
        await context.Response.WriteAsync(error.ToString());
    }
}