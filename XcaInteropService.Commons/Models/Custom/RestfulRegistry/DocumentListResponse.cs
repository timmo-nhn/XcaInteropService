namespace XcaInteropService.Commons.Models.Custom.RestfulRegistry;

public class DocumentListResponse : RestfulApiResponse
{
    public Pagination Pagination { get; set; }
    public List<DocumentListEntry> DocumentListEntries { get; set; }
}