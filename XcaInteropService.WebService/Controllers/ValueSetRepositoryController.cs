using Microsoft.AspNetCore.Mvc;
using XcaInteropService.Commons.Models.Soap;

namespace XcaInteropService.WebService.Controllers;


[Route("/ValueSetRepository/services")]
public class ValueSetRepositoryController : Controller
{
    [HttpPost("ValueSetRepositoryService")]
    public ActionResult RetrieveValueSet([FromBody] SoapEnvelope soapEnvelope)
    {

        return Ok();
    }
}