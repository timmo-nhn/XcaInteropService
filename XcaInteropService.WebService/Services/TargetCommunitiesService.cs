using XcaInteropService.Source.Services;

namespace XcaInteropService.Commons.Models.Custom;

public class TargetCommunitiesService
{
    private readonly ILogger<TargetCommunitiesService> _logger;
    private readonly TargetCommunitiesWrapper _targetCommunitiesWrapper;
    public DomainConfigMap DomainConfig { get; set; }

    public TargetCommunitiesService(ILogger<TargetCommunitiesService> logger, TargetCommunitiesWrapper targetCommunitiesWrapper)
    {
        _logger = logger;
        _targetCommunitiesWrapper = targetCommunitiesWrapper;
        DomainConfig = targetCommunitiesWrapper.ReadDomainConfigMap();
    }
}
