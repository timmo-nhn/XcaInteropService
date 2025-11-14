using XcaInteropService.Commons.Models.Custom.RegistryDtos;

namespace XcaInteropService.Commons.Models.Custom.PolicyDtos;

public class PolicyMatch
{
    public PolicyMatch(string attributeId, string value)
    {
        AttributeId = attributeId;
        Value = value;
    }
    public PolicyMatch()
    {}

    public string? AttributeId { get; set; }
    public string? Value { get; set; }
}