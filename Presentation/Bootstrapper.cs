using Presentation.Middlewares;

namespace Presentation;

public static class Bootstrapper
{
    public static IServiceCollection AddCustomMiddlewares(this IServiceCollection collection)
    {
        collection.AddTransient<GlobalExceptionHandlingMiddleware>();
        return collection;
    }
    
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        return builder;
    }
}