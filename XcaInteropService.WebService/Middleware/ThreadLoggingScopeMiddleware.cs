namespace XcaInteropService.WebService.Middleware;

public class ThreadLoggingScopeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ThreadLoggingScopeMiddleware> _logger;

    public ThreadLoggingScopeMiddleware(RequestDelegate next, ILogger<ThreadLoggingScopeMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        using (_logger.BeginScope(new Dictionary<string, object>
        {
            ["ThreadId"] = Environment.CurrentManagedThreadId
        }))
        {
            await _next(context);
        }
    }
}
