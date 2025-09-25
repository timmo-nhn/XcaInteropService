using Microsoft.AspNetCore.Mvc;
using XcaInteropService.Commons.Extensions;
using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Commons.Models.Custom.RestfulRegistry;

namespace XcaInteropService.WebService.Controllers;

public class DomainConfigController : Controller
{
    private readonly ILogger<DomainConfigController> _logger;
    private readonly TargetCommunitiesService _targetCommunitiesService;

    public DomainConfigController(ILogger<DomainConfigController> logger, TargetCommunitiesService targetCommunitiesService)
    {
        _logger = logger;
        _targetCommunitiesService = targetCommunitiesService;
    }

    [HttpPost("add-domain-config")]
    public ActionResult AddDomainConfig([FromBody] DomainConfig domainConfig)
    {
        var response = new RestfulApiResponse();

        var conflicingInputs = DomainConfigExtensions.GetConflictingInputValues(_targetCommunitiesService.GetDomainConfigMap(), domainConfig);

        if (conflicingInputs.Any())
        {
            response.Success = false;
            response.SetMessage($"Conflicting values {string.Join(", ", conflicingInputs)}");
            return Conflict(response);
        }

        var result = _targetCommunitiesService.UpdateDomainConfigMap(domainConfig);

        response.Success = result;

        if (response.Success)
        {
            response.SetMessage($"Added domain config {domainConfig.DomainOid}");
            return Ok(response);
        }

        response.SetMessage("Error while uploading domain");

        return BadRequest(response);
    }

    [HttpGet("toggle-domain")]
    public ActionResult ToggleDomain(string oid)
    {
        var result = _targetCommunitiesService.ToggleDomain(oid, out var currentValue);

        var response = new RestfulApiResponse()
        {
            Success = result
        };

        if (response.Success)
        {
            response.SetMessage($"Toggled domain {oid} to {currentValue}");
            return Ok(response);
        }

        response.SetMessage($"Couldnt find domain {oid}");
        return NotFound(response);
    }

    [HttpDelete("delete-domain")]
    public ActionResult DeleteDomain(string oid)
    {
        var result = _targetCommunitiesService.RemoveDomainConfig(oid);

        var response = new RestfulApiResponse()
        {
            Success = result
        };

        if (response.Success)
        {
            response.SetMessage($"Deleted domain {oid}");
            return Ok(response);
        }

        response.SetMessage($"Domain not found {oid}");
        return NotFound(response);
    }
}
