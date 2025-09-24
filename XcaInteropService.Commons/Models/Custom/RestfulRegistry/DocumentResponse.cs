using XcaInteropService.Commons.Models.Custom.RegistryDtos;

namespace XcaInteropService.Commons.Models.Custom.RestfulRegistry;

public class DocumentResponse : RestfulApiResponse
{
    public DocumentDto? Document { get; set; }
}
