using XcaInteropService.Commons.Models.Custom.RegistryDtos;

namespace XcaInteropService.Commons.Models.Custom.RestfulRegistry;

public class DocumentListEntry
{
    public DocumentEntryDto DocumentReference { get; set; }
    public LinkToDocument LinkToDocument { get; set; }
}