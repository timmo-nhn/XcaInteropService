using System.Data.SqlTypes;
using System.Text.Json.Serialization;
using XcaInteropService.Commons.Commons;


public class Actor
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ActorType? ActorType {  get; set; }
    public string? UserNin { get; set; }
    public string? UserName { get; set; }
    public string? HprNr { get; set; }
    public string? HprRole { get; set; }
    public string? LegalEntityId { get; set; }
    public string? PointOfCareId { get; set; }
    public string? PurposeOfUse { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AccessBasis? AccessBasis { get; set; }
}