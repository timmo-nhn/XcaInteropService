using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Extensions;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.WebService.Services;

namespace XcaInteropService.WebService.Controllers;

[Route("/ValueSetRepository/services")]
public class ValueSetRepositoryController : Controller
{
    private readonly ILogger<ValueSetRepositoryController> _logger;
    private readonly ValueSetRepositoryService _valueSetRepositoryService;

    public ValueSetRepositoryController(ILogger<ValueSetRepositoryController> logger, ValueSetRepositoryService valueSetRepositoryService)
    {
        _logger = logger;
        _valueSetRepositoryService = valueSetRepositoryService;
    }

    [Consumes("application/soap+xml")]
    [Produces("application/soap+xml")]
    [HttpPost("ValueSetRepositoryService")]
    public IActionResult RetrieveValueSet([FromBody] SoapEnvelope soapEnvelope)
    {
        var responseEnvelope = new SoapEnvelope();

        var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
        var action = soapEnvelope.Header.Action?.Trim();

        var requestTimer = Stopwatch.StartNew();
        _logger.LogInformation($"{soapEnvelope.Header.MessageId} - Received request for action: {action} from {Request.HttpContext.Connection.RemoteIpAddress}");


        switch (action)
        {
            case Constants.Xds.OperationContract.Iti48Action:
                responseEnvelope = _valueSetRepositoryService.RetrieveValueSet(soapEnvelope);
                break;

            case Constants.Xds.OperationContract.Iti60Action:
                responseEnvelope = _valueSetRepositoryService.RetrieveMultipleValueSets(soapEnvelope);
                break;

            default:
                _logger.LogInformation($"{soapEnvelope.Header.MessageId} - Unknown action: {action} from {Request.HttpContext.Connection.RemoteIpAddress}");
                requestTimer.Stop();
                _logger.LogInformation($"{soapEnvelope.Header.MessageId} - Completed action: {action} in {requestTimer.ElapsedMilliseconds} ms");
                return BadRequest(SoapExtensions.CreateSoapFault("soapenv:Reciever", detail: action, faultReason: $"The [action] cannot be processed at the receiver").Value);
        }

        requestTimer.Stop();
        _logger.LogInformation($"{soapEnvelope.Header.MessageId} -  Completed action: {action} in {requestTimer.ElapsedMilliseconds} ms");


        return Ok(responseEnvelope);
    }
}