using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("playingEntity", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class PlayingEntity
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlAttribute("determinerCode")]
    public string? DeterminerCode { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("code")]
    public CE? Code { get; set; }

    [XmlElement("quantity")]
    public PQ? Quantity { get; set; }

    [XmlElement("name")]
    public List<PN>? Name { get; set; }

    [XmlElement("birthTime", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public TS? SdtcBirthTime { get; set; }

    [XmlElement("desc")]
    public ED? Desc { get; set; }
}