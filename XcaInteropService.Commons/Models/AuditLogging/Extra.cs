
using System.Reflection;
using System.Text.Json.Serialization;
using XcaInteropService.Commons.Commons;

namespace Nav.Service.TopicCopier.Types.AuditMessage;

// Enum to declare the type of the http wire content of the message

public class Extra
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MessageType MessageType { get; set; }
    public string? SourceField { get; set; }
    public DateTime LastModified { get; set; }
    public int MessageHash { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public XcaAction? XcaAction { get; set; }
    public List<Resource>? Resource { get; set; }
    public bool IsFinished { get; set; }
    public bool SamlSectionFinished { get; set; }
    public bool ResourceSectionFinished { get; set; }
    public int ProcessedCount { get; set; }
}

public class Resource
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ResourceType? ResourceType { get; set; }
    public string? ResourceTitle { get; set; }
    public DateTime? ResourceDate { get; set; }
    public CodedElement? ConfidentialityCode { get; set; }
    public string? ResourceOwner {  get; set; }
    public string? ResourceOwnerDetails { get; set; }
    public string? ResourceRetrieveId { get; set; }
}

public class CodedElement
{
    public string Code { get; set; }
    public string System { get; set; }
    public string Display{ get; set; }
}

public enum ResourceType
{
    Journaldokument,
    Dokumentliste
}