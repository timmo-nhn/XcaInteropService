using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfContactParty", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFContactParty
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlElement("telecom")]
    public TEL? Telecom { get; set; }
}