using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("maintainedEntity", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class MaintainedEntity
{
    [XmlElement("classCode")]
    public string? ClassCode { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("effectiveTime")]
    public IVL_TS EffectiveTime { get; set; }

    [XmlElement("maintainingPerson")]
    public Person MaintainingPerson { get; set; }
}