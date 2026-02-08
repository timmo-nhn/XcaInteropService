using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcaInteropService.Commons.Models.Custom;

namespace XcaInteropService.Commons.Extensions;

public static  class DomainConfigExtensions
{
    public static List<string> GetConflictingInputValues(DomainConfigMap domainConfigMap, DomainConfig domainConfig)
    {
        var conflicting = new List<string>();

        if (domainConfigMap.Domains.Any(dom => !string.IsNullOrWhiteSpace(dom.HomeCommunityId) && dom.HomeCommunityId == domainConfig.HomeCommunityId))
        {
            conflicting.Add($"OID: {domainConfig.HomeCommunityId}");
        }

        if (domainConfigMap.Domains.Any(dom => !string.IsNullOrWhiteSpace(dom.QueryUrl) && dom.QueryUrl == domainConfig.QueryUrl))
        {
            conflicting.Add($"QueryUrl: {domainConfig.QueryUrl}");
        }

        if (domainConfigMap.Domains.Any(dom => !string.IsNullOrWhiteSpace(dom.RetrieveUrl) && dom.RetrieveUrl == domainConfig.RetrieveUrl))
        {
            conflicting.Add($"RetrieveUrl: {domainConfig.RetrieveUrl}");
        }

        if (domainConfigMap.Domains.Any(dom => !string.IsNullOrWhiteSpace(dom.RetrieveImagesUrl) && dom.RetrieveImagesUrl == domainConfig.RetrieveImagesUrl))
        {
            conflicting.Add($"RetrieveImagesUrl: {domainConfig.RetrieveImagesUrl}");
        }

        return conflicting;
    }
}
