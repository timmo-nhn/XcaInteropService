using System.Xml.Serialization;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

public class ParentDocument
{
    [XmlAttribute("classCode")]
    public string? classCode { get; set; }

    [XmlAttribute("moodCode")]
    public string? moodCode { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("id")]
    public List<II> Id { get; set; }

    [XmlElement("code")]
    public CV? Code { get; set; }

    [XmlElement("text")]
    public ED? Text { get; set; }

    [XmlElement("setId")]
    public II? SetId { get; set; }

    [XmlElement("versionNumber")]
    public INT? VersionNumber { get; set; }
}