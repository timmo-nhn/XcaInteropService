using XcaInteropService.Commons.Models.ClinicalDocument;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("asAgent", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFAsAgent
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; } = "AGNT";

    [XmlElement("representedOrganization")]
    public Organization? RepresentedOrganization { get; set; }
}