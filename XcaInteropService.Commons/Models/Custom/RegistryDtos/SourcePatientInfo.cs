namespace XcaInteropService.Commons.Models.Custom.RegistryDtos;

public class SourcePatientInfo
{
    public PatientId? PatientId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthTime { get; set; }
    public string? Gender { get; set; }
}