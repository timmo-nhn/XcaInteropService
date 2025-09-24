namespace XcaInteropService.Commons.Models.Custom.RegistryDtos;

public class AssociationDto : RegistryObjectDto
{
    public string? AssociationType { get; set; }
    /// <summary>
    /// Usually the RegistryPackage/SubmissionSet
    /// </summary>
    public string? SourceObject { get; set; }
    public string? SubmissionSetStatus { get; set; } = "Original";
    /// <summary>
    /// Usually the ExtrinsicObject/DocumentReference
    /// </summary>
    public string? TargetObject { get; set; }
}