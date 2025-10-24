using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfProviderOrganization", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFProviderOrganization
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; } = "ORG";
    
    [XmlAttribute("determinerCode")]
    public string? DeterminerCode { get; set; } = "INSTANCE";

    [XmlElement("id")]
    public List<II>? Id { get; set; }

    [XmlElement("name")]
    public ENXP Name { get; set; }

    [XmlElement("contactParty")]
    public CFContactParty ContactParty { get; set; }
}