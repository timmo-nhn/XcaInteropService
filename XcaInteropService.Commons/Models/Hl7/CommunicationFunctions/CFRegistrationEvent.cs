using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfRegistrationEvent", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFRegistrationEvent : Act
{
    [XmlAttribute("classCode")]
    public string ClassCode { get; set; } = "REG";

    [XmlAttribute("moodCode")]
    public string MoodCode { get; set; } = "EVN";

    [XmlElement("subject1")]
    public CFSubject1? Subject1 { get; set; }   

    [XmlElement("custodian")]
    public Custodian? Custodian { get; set; }   
}