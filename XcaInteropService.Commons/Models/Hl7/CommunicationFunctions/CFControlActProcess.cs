using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("controlActProcess", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFControlActProcess
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; } = "CACT";
    
    [XmlAttribute("moodCode")]
    public string? MoodCode { get; set; } = "EVN";

    [XmlElement("subject")]
    public CFSubject? Subject { get; set; }
}