using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("order", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Order
{
    [XmlAttribute("classCode")]
    public string classCode { get; set; }

    [XmlAttribute("moodCode")]
    public string? moodCode { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("id")]
    public List<II> Id { get; set; }

    [XmlElement("code")]
    public CE? Code { get; set; }

    [XmlElement("prioritycode")]
    public CE? PriorityCode { get; set; }

}