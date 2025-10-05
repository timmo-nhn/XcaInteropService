using System.Xml.Serialization;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[XmlType("Group")]
public class GroupType
{
    [XmlAttribute("id")]
    public string? Id { get; set; }

    [XmlAttribute("sourceOrganization")]
    public string? SourceOrganization { get; set; }

    [XmlAttribute("displayName")]
    public string? DisplayName { get; set; }
}