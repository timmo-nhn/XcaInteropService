using XcaInteropService.Source.Models.DatabaseDtos.Types;

namespace XcaInteropService.Source.Models.DatabaseDtos;

public class DbPatientIdentityDto
{
    public string? Id { get; set; }
    public string? NameFirstName { get; set; }
    public string? NameLastName { get; set; }
    public string? GenderCode { get; set; }
    public string? GenderCodeSystem { get; set; }
    public string? GenderDisplayName { get; set; }
    public DateTime? BirthTime { get; set; }
    public DateTime? DeceasedTime { get; set; }
    public string? IdentifierCode { get; set; }
    public string? IdentifierCodeSystem { get; set; }
    public string? IdentifierCodeSystemAuthority { get; set; }
    public List<DbCodedIdentifier>? AlternatePatientIdentifiers { get; set; }
}