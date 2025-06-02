using System.Diagnostics;

namespace ClockCalculator.Api.Middleware;

public class RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        
        await next(context);
        
        stopwatch.Stop();
        var duration = stopwatch.ElapsedMilliseconds;
        
        logger.LogInformation("Request {Method} {Path} completed in {Duration}ms", 
            context.Request.Method, 
            context.Request.Path, 
            duration);
    }
}