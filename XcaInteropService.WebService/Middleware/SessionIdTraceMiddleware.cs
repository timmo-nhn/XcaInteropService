using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Extensions;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.WebService.Middleware;

public class SessionIdTraceMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<SessionIdTraceMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public SessionIdTraceMiddleware(RequestDelegate next, ILogger<SessionIdTraceMiddleware> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var contentType = httpContext.Request.ContentType?.Split(";").First();

        httpContext.Request.EnableBuffering();

        var requestBody = await httpContext.Request.GetHttpRequestBodyAsStringAsync();

        if (requestBody.StartsWith("--MIMEBoundary") || httpContext.Request.Headers.ContentType.Any(ct => ct != null && ct.Contains("MIMEBoundary")))
        {
            requestBody = await HttpRequestResponseExtensions.ReadMultipartContentFromRequest(httpContext);
        }


        switch (contentType)
        {
            case Constants.MimeTypes.XopXml:
            case Constants.MimeTypes.MultipartRelated:
            case Constants.MimeTypes.SoapXml:

                var sxmls = new SoapXmlSerializer();

                var soapEnvelope = sxmls.DeserializeXmlString<SoapEnvelope>(requestBody);

                httpContext.TraceIdentifier = soapEnvelope.Header.MessageId ?? Guid.NewGuid().ToString();

                break;

            default:
                httpContext.TraceIdentifier = Guid.NewGuid().ToString();
                break;
        }

        _logger.LogInformation($"{httpContext.TraceIdentifier} - Trace identifier set: {httpContext.TraceIdentifier}");
        await _next(httpContext);
    }
}