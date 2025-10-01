using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("ValueSetRepositoryService")]
    public IActionResult RetrieveValueSet([FromBody] SoapEnvelope soapEnvelope)
    {
        var soapAction = soapEnvelope.Header.Action;

        var valueSetResponse = _valueSetRepositoryService.RetrieveValueSet(soapEnvelope);
        return Ok();
    }
}