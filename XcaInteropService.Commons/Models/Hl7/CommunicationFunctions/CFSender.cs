using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfSender", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFSender
{
    [XmlAttribute("typeCode")]
    public string TypeCode { get; set; } = "SND";

    [XmlElement("device")]
    public CFDevice? Device { get; set; }
}
