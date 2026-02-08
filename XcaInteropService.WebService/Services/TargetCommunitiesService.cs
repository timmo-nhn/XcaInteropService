using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Source.Services;

namespace XcaInteropService.WebService.Services;

public class TargetCommunitiesService
{
    private readonly ILogger<TargetCommunitiesService> _logger;
    private readonly TargetCommunitiesWrapper _targetCommunitiesWrapper;

    public TargetCommunitiesService(ILogger<TargetCommunitiesService> logger, TargetCommunitiesWrapper targetCommunitiesWrapper)
    {
        _logger = logger;
        _targetCommunitiesWrapper = targetCommunitiesWrapper;
    }

    public DomainConfigMap GetDomainConfigMap()
    {
        return _targetCommunitiesWrapper.ReadDomainConfigMap();
    }

    public bool UpdateDomainConfigMap(DomainConfig domainConfig)
    {

        var configMap = _targetCommunitiesWrapper.ReadDomainConfigMap();

        configMap.Domains.Add(domainConfig);

        var result = _targetCommunitiesWrapper.WriteConfigMap(configMap);
        return result;
    }

    public bool RemoveDomainConfig(string oid)
    {
        var configMap = _targetCommunitiesWrapper.ReadDomainConfigMap();

        var idx = configMap.Domains.FindIndex(dom => dom.HomeCommunityId == oid);

        if (idx == -1) return false;

        configMap.Domains.RemoveAt(idx);

        var result = _targetCommunitiesWrapper.WriteConfigMap(configMap);

        return result;
    }

    public bool ToggleDomain(string oid, out bool? currentValue)
    {
        var configMap = _targetCommunitiesWrapper.ReadDomainConfigMap();

        var theDomain = configMap.Domains.FirstOrDefault(dom => dom.HomeCommunityId == oid);


        if (theDomain == null)
        {
            currentValue = null;
            return false;
        }

        theDomain.Enabled = !theDomain.Enabled;

        currentValue = theDomain.Enabled;

        var result = _targetCommunitiesWrapper.WriteConfigMap(configMap);

        return result;
    }
}
