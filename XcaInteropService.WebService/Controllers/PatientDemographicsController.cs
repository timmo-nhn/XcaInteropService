using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.WebService.Services;

namespace XcaInteropService.WebService.Controllers;

[ApiController]
[Route("PIXPDQ/services")]
public class PatientDemographicsController : Controller
{
    private readonly ILogger<PatientDemographicsController> _logger;
    private readonly PatientDemographicsService _patientDemographicsService;

    public PatientDemographicsController(ILogger<PatientDemographicsController> logger, PatientDemographicsService patientDemographicsService)
    {
        _logger = logger;
        _patientDemographicsService = patientDemographicsService;
    }



    [Consumes("application/soap+xml")]
    [Produces("application/soap+xml")]
    [HttpPost("PIXPDQV3ManagerService")]
    public IActionResult HandlePixRequest([FromBody] SoapEnvelope soapEnvelope)
    {
        var responseEnvelope = new SoapEnvelope();

        var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
        var action = soapEnvelope.Header.Action?.Trim();

        var requestTimer = Stopwatch.StartNew();
        _logger.LogInformation($"{soapEnvelope.Header.MessageId} - Received request for action: {action} from {Request.HttpContext.Connection.RemoteIpAddress}");

        switch (action)
        {
            case Constants.Xds.OperationContract.Iti44Action:
               var addPatientResponse = _patientDemographicsService.UploadPatientIdentity(soapEnvelope);
                break;

            default:
                break;
        }

        return Ok(responseEnvelope);
    }
}
