namespace XcaInteropService.Commons.Models.Custom.RegistryDtos;

public class AuthorInfo
{
    public AuthorOrganization? Organization { get; set; }
    public AuthorOrganization? Department { get; set; }
    public AuthorPerson? Person { get; set; }
    public CodedValue? Role { get; set; }
    public CodedValue? Speciality { get; set; }
}