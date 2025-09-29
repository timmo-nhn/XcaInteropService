using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Extensions;
using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Serializers;
using XcaInteropService.WebService.Services;

namespace XcaInteropService.WebService.Controllers;

[ApiController]
[Route("XCA/services")]
public class InitiatingGatewayController : ControllerBase
{
    private readonly ILogger<InitiatingGatewayController> _logger;
    private readonly TargetCommunitiesService _targetCommunitiesService;
    private readonly InitiatingGatewayService _initiatingGatewayService;

    public InitiatingGatewayController(ILogger<InitiatingGatewayController> logger, TargetCommunitiesService targetCommunitiesService, InitiatingGatewayService initiatingGatewayService)
    {
        _logger = logger;
        _targetCommunitiesService = targetCommunitiesService;
        _initiatingGatewayService = initiatingGatewayService;
    }

    [Consumes("application/soap+xml", "application/xml", "multipart/related", "application/xop+xml")]
    [Produces("application/soap+xml", "application/xop+xml", "application/octet-stream", "multipart/related")]
    [HttpPost("InitiatingGatewayService")]
    public async Task<IActionResult> HandleInitiatingGatewayRequest([FromBody] SoapEnvelope soapEnvelope)
    {
        var action = soapEnvelope.Header.Action?.Trim();

        var sxmls = new SoapXmlSerializer();

        var responseEnvelope = new SoapEnvelope();
        responseEnvelope.Body = new();

        var requestTimer = Stopwatch.StartNew();
        _logger.LogInformation($"{Request.HttpContext.TraceIdentifier} - Received request for action: {action} from {Request.HttpContext.Connection.RemoteIpAddress}");

        var domainConfigMap = _targetCommunitiesService.GetDomainConfigMap();

        if (soapEnvelope.Header.ReplyTo?.Address != Constants.Soap.Addresses.Anonymous)
        {
            action += "Async";
        }

        switch (action)
        {
            case Constants.Xds.OperationContract.Iti38Action:

                var runningTasks = new List<Task<HttpResponseMessage>>();

                foreach (var targetCommunity in domainConfigMap.Domains)
                {
                    if (!targetCommunity.Enabled) continue;

                    runningTasks.Add(_initiatingGatewayService.CrossGatewayQueryFromTargetCommunity(soapEnvelope, targetCommunity));
                }

                var results = await Task.WhenAll(runningTasks);

                responseEnvelope = await _initiatingGatewayService.ProcessCrossGatewayQueryResponseMessages(results, Request.HttpContext.TraceIdentifier, domainConfigMap);

                break;


            case Constants.Xds.OperationContract.Iti39Action:
                responseEnvelope = await _initiatingGatewayService.CrossGatewayRetrieveFromTargetCommunity(soapEnvelope, Request.HttpContext.TraceIdentifier, domainConfigMap);

                responseEnvelope.Header = new();
                responseEnvelope.Header.Action = soapEnvelope.GetCorrespondingResponseAction();

                var multipartResponse = HttpRequestResponseExtensions.ConvertToMultipartMessage(responseEnvelope, out var boundary);

                string contentId = null;

                if (multipartResponse.FirstOrDefault()?.Headers.TryGetValues("Content-ID", out var contentIdValues) ?? false)
                {
                    contentId = contentIdValues.First();
                }

                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = multipartResponse
                };

                requestTimer.Stop();
                _logger.LogInformation($"Completed action: {action} in {requestTimer.ElapsedMilliseconds} ms");

                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();

                var streamResult = new FileContentResult(bytes, $"multipart/related; type=\"{Constants.MimeTypes.XopXml}\"; boundary=\"{boundary}\"; start=\"{contentId}\"; start-info=\"{Constants.MimeTypes.SoapXml}\"");

                _logger.LogInformation($"{soapEnvelope.Header.MessageId} - " + streamResult.ContentType);

                _logger.LogInformation($"{soapEnvelope.Header.MessageId} - " + Encoding.UTF8.GetString(bytes));

                return streamResult;

            default:
                break;
        }
        responseEnvelope.Header = new();
        responseEnvelope.Header.Action = soapEnvelope.GetCorrespondingResponseAction();

        return Ok(responseEnvelope);
    }
}
