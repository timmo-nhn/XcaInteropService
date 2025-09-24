namespace XcaInteropService.Commons.Models.Custom.RegistryDtos;

public class SubmissionSetDto : RegistryObjectDto
{
    public List<AuthorInfo>? Author { get; set; }
    public string? AvailabilityStatus { get; set; }
    public string? HomeCommunityId { get; set; }
    public CodedValue? PatientId { get; set; }
    public DateTime? SubmissionTime { get; set; }
    public string? Title { get; set; }
    public string? UniqueId { get; set; }
    public string? SourceId { get; set; }
}