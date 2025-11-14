using XcaInteropService.Commons.Models.ClinicalDocument.Types;
using XcaInteropService.Commons.Models.Hl7.DataType;

namespace XcaInteropService.Commons.Models.Custom.PatientIdentityDtos;

public class PatientIdentityDto
{
    public string? Id { get; set; }
    public XPN? Name { get; set; }
    public CE? GenderCode {  get; set; }
    public DateTime? BirthTime { get; set; }
    public DateTime? DeceasedTime { get; set; }
    public CX? Identifier { get; set; }
    public List<CX>? AlternateIdentifiers { get; set; }
}
