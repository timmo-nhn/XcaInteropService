using System.Xml.Serialization;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

public class ExternalDocument : ExternalBase
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlAttribute("moodCode")]
    public string? MoodCode { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("id")]
    public List<II>? Id { get; set; }

    [XmlElement("code")]
    public CD Code { get; set; }

    [XmlElement("text")]
    public ED? Text { get; set; }

    [XmlElement("setId")]
    public II? SetId { get; set; }

    [XmlElement("versionNumber")]
    public INT? VersionNumber { get; set; }
}
