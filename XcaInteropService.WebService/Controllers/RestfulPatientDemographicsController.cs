using Microsoft.AspNetCore.Mvc;
using XcaInteropService.WebService.Services;

namespace XcaInteropService.WebService.Controllers;

[ApiController]
[Route("restful-pix")]
public class RestfulPatientDemographicsController : Controller
{
    private readonly ILogger<RestfulPatientDemographicsController> _logger;
    private readonly PatientDemographicsService _patientService;

    public RestfulPatientDemographicsController(ILogger<RestfulPatientDemographicsController> logger, PatientDemographicsService patientService)
    {
        _patientService = patientService;
        _logger = logger;
    }

    [HttpGet("get-all-identifiers")]
    public IActionResult GetAllConcepts()
    {
        return Ok("ok");
    }
}
