using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfSubject1", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFSubject1
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("patient")]
    public CFPatient? Patient { get; set; }
}