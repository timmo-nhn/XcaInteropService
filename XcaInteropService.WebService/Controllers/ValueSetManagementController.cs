using Microsoft.AspNetCore.Mvc;
using XcaInteropService.Commons.Models.Soap.XdsTypes;
using XcaInteropService.WebService.Services;

namespace XcaInteropService.WebService.Controllers;


[Route("valueset-management")]
public class ValueSetManagementController : Controller
{
    private readonly ILogger<ValueSetManagementController> _logger;
    private readonly ValueSetRepositoryService _valueSetRepositoryService;

    public ValueSetManagementController(ILogger<ValueSetManagementController> logger, ValueSetRepositoryService valueSetRepositoryService)
    {
        _logger = logger;
        _valueSetRepositoryService = valueSetRepositoryService;
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
}