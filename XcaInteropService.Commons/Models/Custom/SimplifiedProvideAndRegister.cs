using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Custom;

public class SimplifiedProvideAndRegister
{
    public string SubmissionSetStatus { get; set; } = string.Empty;
    public DateTime CreationTime { get; set; } = new DateTime();
    public string LanguageCode { get; set; } = string.Empty;
    public DateTime ServiceStartTime { get; set; } = new DateTime();
    public DateTime ServiceStopTime { get; set; } = new DateTime();
    public string SourcePatientId { get; set; } = string.Empty;
    public SourcePatientInfo SourcePatientInfo { get; set; } = new SourcePatientInfo();
    public string RepositoryUniqueId { get; set; } = string.Empty;
    public string SubmissionTitle { get; set; } = string.Empty;
    public string ClassificationAuthorPerson { get; set; } = string.Empty;
    public Author ClassificationAuthorInstitution { get; set; } = new Author();
    public string ClassificationFormatCode { get; set; } = string.Empty;
    public string ClassificationHealthCareFacilityTypeCode { get; set; } = string.Empty;
    public string ClassificationPracticeSettingCode { get; set; } = string.Empty;
    public string ClassificationDocumentClassCode { get; set; } = string.Empty;
    public string ClassificationDocumentTypeCode { get; set; } = string.Empty;
    public ConceptType ClassificationConfidentialityCode { get; set; } = new() { Code = string.Empty, CodeSystemName = string.Empty, DisplayName = string.Empty };
    public string ExternalIdentifierUniqueId { get; set; } = string.Empty;
    public string ExternalIdentifierPatientId { get; set; } = string.Empty;
}
