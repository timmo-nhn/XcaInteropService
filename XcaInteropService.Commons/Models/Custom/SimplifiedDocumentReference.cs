namespace XcaInteropService.Commons.Models.Custom;

public class SimplifiedDocumentReference
{
    public string XmlStringRepresentation { get; set; }
    public string Id { get; set; }
    public string DocumentId { get; set; }
    public string HomeCommunityId { get; set; }
    public string RepositoryId { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string ConfidentialityCode { get; set; }
    public string DocumentClassification { get; set; }
    public string DocumentType { get; set; }
    public string Department { get; set; }
    public string Institution { get; set; }
}
