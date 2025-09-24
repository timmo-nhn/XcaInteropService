using XcaInteropService.Commons.Enums;

namespace XcaInteropService.Commons.Models.Custom;

public class DomainConfig
{
    public string DomainOid { get; set; }
    public bool Async { get; set; }
    public bool Enabled { get; set; }
    public PatientResolverType PatientResolverType { get; set; }
    public string QueryUrl { get; set; }
    public string RetrieveUrl { get; set; }
    public string RetrieveImagesUrl { get; set; }
}