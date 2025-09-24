namespace XcaInteropService.Commons.Models.Custom.RegistryDtos.TestData;

public class TestAuthors
{
    public List<AuthorOrganization> Organizations { get; set; }
    public List<AuthorOrganization> Departments { get; set; }
    public List<AuthorPerson> Persons{ get; set; }
    public List<CodedValue> Roles { get; set; }
    public List<CodedValue> Specialities { get; set; }
}