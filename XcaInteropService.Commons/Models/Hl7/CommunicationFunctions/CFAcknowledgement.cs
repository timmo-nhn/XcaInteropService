using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfAcknowledgement", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFAcknowledgement
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("targetMessage")]
    public List<II>? Id { get; set; }

    [XmlElement("acknowledgementDetail")]
    public CFAcknowledgementDetail? AcknowledgementDetail { get; set; }
}