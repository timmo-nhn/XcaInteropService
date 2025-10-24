using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap;

namespace XcaInteropService.WebService.Controllers;

[ApiController]
[Route("PIXPDQ/services")]
public class PatientDemographicsController : Controller
{
    private readonly ILogger<PatientDemographicsController> _logger;

    public PatientDemographicsController(ILogger<PatientDemographicsController> logger)
    {
        _logger = logger;
    }



    [Consumes("application/soap+xml")]
    [Produces("application/soap+xml")]
    [HttpPost("PIXPDQManagerService")]
    public IActionResult GetDomainConfigMap([FromBody] SoapEnvelope soapEnvelope)
    {
        var responseEnvelope = new SoapEnvelope();

        var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
        var action = soapEnvelope.Header.Action?.Trim();

        var requestTimer = Stopwatch.StartNew();
        _logger.LogInformation($"{soapEnvelope.Header.MessageId} - Received request for action: {action} from {Request.HttpContext.Connection.RemoteIpAddress}");

        switch (action)
        {
            case Constants.Xds.OperationContract.Iti44Action:

                break;

            default:
                break;
        }

        return Ok(responseEnvelope);
    }
}
