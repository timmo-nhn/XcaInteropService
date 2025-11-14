using Abc.Xacml.Policy;

namespace XcaInteropService.Commons.Models.Custom.PolicyDtos;

public class PolicySetDto
{
    public PolicySetDto()
    {
        SetId = Guid.NewGuid().ToString();
    }

    public string SetId { get; set; }
    public string? CombiningAlgorithm { get; set; }
    public List<PolicyDto>? Policies { get; set; }
}