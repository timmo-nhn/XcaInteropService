using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("supply", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Supply : EntryItemBase
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

    [XmlElement("code")]
    public CD? Code { get; set; }

    [XmlElement("text")]
    public ED? Text { get; set; }

    [XmlElement("statusCode")]
    public CS? StatusCode { get; set; }

    [XmlElement("effectiveTime")]
    public List<SXCM_TS>? EffectiveTime { get; set; }

    [XmlElement("priorityCode")]
    public List<CE>? PriorityCode { get; set; }

    [XmlElement("repeatNumber")]
    public IVL_INT? RepeatNumber { get; set; }

    [XmlElement("independentInd")]
    public BL? IndependentInd { get; set; }

    [XmlElement("quantity")]
    public PQ? Quantity { get; set; }

    [XmlElement("expectedUseTime")]
    public IVL_TS? ExcpectedUseTime { get; set; }

    [XmlElement("product")]
    public Product? Product { get; set; }

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