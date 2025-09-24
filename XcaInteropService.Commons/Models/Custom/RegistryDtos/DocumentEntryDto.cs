
namespace XcaInteropService.Commons.Models.Custom.RegistryDtos;

public class DocumentEntryDto : RegistryObjectDto
{
    public List<AuthorInfo>? Author { get; set; }
    public string? AvailabilityStatus { get; set; }
    public CodedValue? ClassCode { get; set; }
    public List<CodedValue>? ConfidentialityCode { get; set; }
    public DateTime? CreationTime { get; set; }
    public CodedValue? EventCodeList { get; set; }
    public CodedValue? FormatCode { get; set; }
    public string? Hash { get; set; }
    public CodedValue? HealthCareFacilityTypeCode { get; set; }
    public string? HomeCommunityId { get; set; }
    public string? LanguageCode { get; set; }
    public LegalAuthenticator? LegalAuthenticator { get; set; }
    public string? MimeType { get; set; }
    public string? ObjectType { get; set; }
    public CodedValue? PatientId { get; set; }
    public CodedValue? PracticeSettingCode { get; set; }
    public string? RepositoryUniqueId { get; set; }
    public string? Size { get; set; }
    public DateTime? ServiceStartTime { get; set; }
    public DateTime? ServiceStopTime { get; set; }
    public SourcePatientInfo? SourcePatientInfo { get; set; }
    public string? Title { get; set; }
    public CodedValue? TypeCode { get; set; }
    public string? UniqueId { get; set; }
}