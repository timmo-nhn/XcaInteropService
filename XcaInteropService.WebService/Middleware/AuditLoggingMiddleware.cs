using System.Diagnostics;
using XcaXds.WebService.Attributes;

namespace XcaInteropService.WebService.Middleware;

public class AuditLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AuditLoggingMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public AuditLoggingMiddleware(RequestDelegate next, ILogger<AuditLoggingMiddleware> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        Stopwatch sw = Stopwatch.StartNew();

        var endpoint = httpContext.GetEndpoint();
        var enforceAttr = endpoint?.Metadata.GetMetadata<UseAuditLoggingMiddlewareAttribute>();

        if (enforceAttr == null || enforceAttr.Enabled == false)
        {
            sw.Stop();
            _logger.LogInformation($"{httpContext.TraceIdentifier} - Ran through PolicyEnforcementPoint-middleware in {sw.ElapsedMilliseconds} ms");
            await _next(httpContext); // Skip PEP check
            return;
        }

    }
}
