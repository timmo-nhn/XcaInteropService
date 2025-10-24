using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfReceiver", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFReceiver
{
    [XmlAttribute("typeCode")]
    public string TypeCode { get; set; } = "RCV";

    [XmlElement("device")]
    public CFDevice Device { get; set; }
}
