using XcaInteropService.Commons.Models.Custom.RegistryDtos;
using XcaInteropService.Commons.Models.Custom.RegistryDtos.TestData;

public class Test_SubmissionSetValues
{
    public TestAuthors Authors { get; set; }
    public List<string> AvailabilityStatuses { get; set; }
    public List<string> HomeCommunityIds { get; set; }
    public List<CodedValue> PatientIds { get; set; }
    public List<DateTime> SubmissionTimes { get; set; }
    public List<string> Titles { get; set; }
    public List<string> UniqueIds { get; set; }
    public List<string> SourceIds { get; set; }
}
