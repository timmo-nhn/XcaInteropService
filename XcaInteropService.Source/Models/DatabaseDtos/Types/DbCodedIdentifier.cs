namespace XcaInteropService.Source.Models.DatabaseDtos.Types;

public class DbCodedIdentifier
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Code { get; set; }
    public string? CodeSystem { get; set; }
    public string? CodeSystemAuthority { get; set; }
}
