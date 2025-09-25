using Microsoft.AspNetCore.Mvc;
using XcaInteropService.Commons.Models.Soap;

namespace XcaInteropService.WebService.Controllers;

public class SharedValueSetController : Controller
{
    [HttpPost]
    public ActionResult RetrieveValueSet([FromBody] SoapEnvelope soapEnvelope)
    {

        return Ok();
    }
}