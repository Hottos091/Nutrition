using System.Diagnostics;

namespace Nutrition.API.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        await next.Invoke(context);
        stopwatch.Stop();

        if((stopwatch.ElapsedMilliseconds / 1000) > 5)
        {
            logger.LogWarning("[{Request}] {Path} took {TimeMs} ms !",                
                context.Request.Method,
                context.Request.Path,
                stopwatch.ElapsedMilliseconds);
        }
    }

}
