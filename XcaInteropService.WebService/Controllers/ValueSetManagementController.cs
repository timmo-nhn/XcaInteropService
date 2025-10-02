using Microsoft.AspNetCore.Mvc;
using XcaInteropService.Commons.Models.Custom.RestfulRegistry;
using XcaInteropService.Commons.Models.Soap.XdsTypes;
using XcaInteropService.WebService.Services;

namespace XcaInteropService.WebService.Controllers;

[ApiController]
[Route("valueset")]
public class ValueSetManagementController : Controller
{
    private readonly ILogger<ValueSetManagementController> _logger;
    private readonly ValueSetRepositoryService _valueSetRepositoryService;

    public ValueSetManagementController(ILogger<ValueSetManagementController> logger, ValueSetRepositoryService valueSetRepositoryService)
    {
        _logger = logger;
        _valueSetRepositoryService = valueSetRepositoryService;
    }

    [HttpGet("get-concept")]
    public IActionResult GetConcept(bool? asXml = false)
    {
        var valueSet = _valueSetRepositoryService.GetValueSetList();

        return Ok(valueSet);
    }

    [HttpGet("upload-concept")]
    public IActionResult UploadConcept(string oid, string language, string code, string codeSystem, string displayName)
    {
        var uploadResponse = _valueSetRepositoryService.UploadSingleConcept(oid, language, code, codeSystem, displayName);

        return Ok();
    }

    [HttpPost("upload-concept-list")]
    public IActionResult UploadConceptList([FromQuery] string oid, [FromQuery] string language, [FromBody] List<ConceptType> conceptListTypes)
    {
        var uploadResponse = _valueSetRepositoryService.UploadConceptList(oid, language, conceptListTypes);

        return Ok();
    }

    [Consumes("application/xml")]
    [HttpPost("upload-value-set-xml")]
    public IActionResult UploadConceptListXml([FromQuery] string oid, [FromQuery] string language, [FromBody] ValueSetType valueSet)
    {
        var uploadResponse = _valueSetRepositoryService.UploadConceptList(oid, language, valueSet);

        return Ok();
    }
}