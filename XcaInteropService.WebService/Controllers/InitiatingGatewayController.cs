using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Custom;

namespace XcaInteropService.WebService.Controllers;

[ApiController]
[Route("XCA/services/IntiatingGatewayService")]
public class InitiatingGatewayController : ControllerBase
{
    private readonly ILogger<InitiatingGatewayController> _logger;
    private readonly TargetCommunitiesService _targetCommunitiesService;

    public InitiatingGatewayController(ILogger<InitiatingGatewayController> logger, TargetCommunitiesService targetCommunitiesService)
    {
        _logger = logger;
        _targetCommunitiesService = targetCommunitiesService;
    }

    [Consumes("application/soap+xml", "application/xml", "multipart/related", "application/xop+xml")]
    [Produces("application/soap+xml", "application/xop+xml", "application/octet-stream", "multipart/related")]
    [HttpPost("RespondingGatewayService")]
    public async Task<IActionResult> HandleInitiatingGatewayRequest([FromBody] SoapEnvelope soapEnvelope)
    {
        var action = soapEnvelope.Header.Action?.Trim();

        var responseEnvelope = new SoapEnvelope();
        var requestTimer = Stopwatch.StartNew();
        _logger.LogInformation($"Received request for action: {action} from {Request.HttpContext.Connection.RemoteIpAddress}");

        if (soapEnvelope.Header.ReplyTo?.Address != Constants.Soap.Addresses.Anonymous)
        {
            action += "Async";
        }

        switch (action)
        {
            case Constants.Xds.OperationContract.Iti38Action:
                foreach (var targetCommunity in _targetCommunitiesService.Domains)
                {

                }

                break;


            case Constants.Xds.OperationContract.Iti39Action:
                break;

            default:
                break;
        }

        return Ok();
    }
}
