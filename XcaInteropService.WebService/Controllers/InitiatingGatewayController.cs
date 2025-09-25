using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using XcaInteropService.Commons.Commons;
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
        var requestTimer = Stopwatch.StartNew();
        _logger.LogInformation($"{Request.HttpContext.TraceIdentifier} - Received request for action: {action} from {Request.HttpContext.Connection.RemoteIpAddress}");

        if (soapEnvelope.Header.ReplyTo?.Address != Constants.Soap.Addresses.Anonymous)
        {
            action += "Async";
        }

        switch (action)
        {
            case Constants.Xds.OperationContract.Iti38Action:

                var domainConfigMap = _targetCommunitiesService.GetDomainConfigMap();

                var runningTasks = new List<Task<HttpResponseMessage>>();

                foreach (var targetCommunity in domainConfigMap.Domains)
                {
                    if (!targetCommunity.Enabled) continue;

                    runningTasks.Add(_initiatingGatewayService.CrossGatewayQueryFromTargetCommunity(soapEnvelope, targetCommunity));
                }

                HttpResponseMessage[] results = await Task.WhenAll(runningTasks);

                foreach (var response in results)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation($"{Request.HttpContext.TraceIdentifier} - Got success from {response.RequestMessage?.RequestUri}");
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var communitySoapEnvelope = sxmls.DeserializeSoapMessage<SoapEnvelope>(responseBody);
                        var registryObjects = communitySoapEnvelope.Body.AdhocQueryResponse?.RegistryObjectList;
                        var registryErrors = communitySoapEnvelope.Body.AdhocQueryResponse?.RegistryErrorList?.RegistryError;
                        
                        _logger.LogInformation($"{Request.HttpContext.TraceIdentifier} - Retrieved {registryObjects?.Length ?? 0} Registry objects");

                        if (registryObjects == null || registryObjects?.Length == 0) continue;

                        responseEnvelope.Body ??= new();
                        responseEnvelope.Body.AdhocQueryResponse ??= new();
                        responseEnvelope.Body.AdhocQueryResponse.RegistryErrorList ??= new();

                        if (registryObjects != null && registryObjects.Length != 0)
                        {
                            responseEnvelope.Body.AdhocQueryResponse.RegistryObjectList = [.. registryObjects];
                        }

                        if (registryErrors != null && registryErrors?.Length != 0)
                        {
                            responseEnvelope.Body.AdhocQueryResponse.RegistryErrorList.RegistryError = [.. registryErrors];
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"{Request.HttpContext.TraceIdentifier} - Gateway {response.RequestMessage?.RequestUri} failed with status {response.StatusCode}");
                    }
                }

                break;


            case Constants.Xds.OperationContract.Iti39Action:
                break;

            default:
                break;
        }

        return Ok(responseEnvelope);
    }
}
