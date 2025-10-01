using XcaInteropService.Commons.Enums;

namespace XcaInteropService.Commons.Models.Custom;

public class DomainConfig
{
    public string? FriendlyName { get; set; }
    public string DomainOid { get; set; }
    public bool Async { get; set; } = false;
    public bool Enabled { get; set; } = true;
    public PatientResolverType PatientResolverType { get; set; } = PatientResolverType.IDENTITY;
    public string QueryUrl { get; set; }
    public string? RetrieveUrl { get; set; }
    public string? RetrieveImagesUrl { get; set; }
}