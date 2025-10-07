namespace XcaInteropService.Commons.Models.Custom;

public class DomainConfigMap
{
    public DomainConfigMap()
    {
        Domains ??= new();
    }

    public List<DomainConfig> Domains { get; set; }
}
