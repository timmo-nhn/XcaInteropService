using System.Xml.Serialization;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

public class AlternateIdentification
{
    [XmlAttribute("classCode")]
    public string ClassCode { get; set; }

    [XmlElement("id")]
    public II Id { get; set; }

    [XmlElement("code")]
    public CD? Code { get; set; }

    [XmlElement("statusCode")]
    public CS? StatusCode { get; set; }

    [XmlElement("effectiveTime")]
    public IVL_TS? EffectiveTime { get; set; }
}