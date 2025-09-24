using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("observationMedia", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ObservationMedia : EntryItemBase
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlAttribute("moodCode")]
    public string? MoodCode { get; set; }

    [XmlElement("realmCode")]
    public List<CS>? RealmCode { get; set; }

    [XmlElement("typeId")]
    public II? TypeId { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("id")]
    public List<II>? Id { get; set; }

    [XmlElement("languageCode")]
    public CS? LanguageCode { get; set; }

    [XmlElement("value")]
    public ED Value { get; set; }

    [XmlElement("subject")]
    public Subject? Subject { get; set; }

    [XmlElement("speciment")]
    public List<Specimen>? Specimen { get; set; }

    [XmlElement("performer")]
    public List<Performer2>? Performer { get; set; }

    [XmlElement("author")]
    public List<Author>? Author { get; set; }

    [XmlElement("informant")]
    public List<Informant>? Informant { get; set; }

    [XmlElement("participant")]
    public List<Participant2>? Participant { get; set; }

    [XmlElement("entryRelationship")]
    public List<EntryRelationship>? EntryRelationship { get; set; }

    [XmlElement("reference")]
    public List<Reference>? Reference { get; set; }

    [XmlElement("precondition")]
    public List<Precondition>? Precondition { get; set; }
}