using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("substanceAdministration", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class SubstanceAdministration : EntryItemBase
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

    [XmlIgnore]
    private bool? _negationInd;

    [XmlAttribute("negationInd")]
    public string? NegationInd
    {
        get => _negationInd.HasValue ? _negationInd.ToString().ToLowerInvariant() : null;
        set => _negationInd = string.IsNullOrEmpty(value) ? null : bool.Parse(value);
    }

    [XmlElement("text")]
    public ED? Text { get; set; }

    [XmlElement("statusCode")]
    public CS? StatusCode { get; set; }

    [XmlElement("effectiveTime")]
    public List<SXCM_TS>? EffectiveTime { get; set; }

    [XmlElement("priorityCode")]
    public CE? PriorityCode { get; set; }

    [XmlElement("repeatNumber")]
    public IVL_INT? RepeatNumber { get; set; }

    [XmlElement("routeCode")]
    public CE? RouteCode { get; set; }

    [XmlElement("approachSiteCode")]
    public List<CD>? ApproachSiteCode { get; set; }

    [XmlElement("doseQuantity")]
    public IVL_PQ? DoseQuantity { get; set; }

    [XmlElement("rateQuantity")]
    public IVL_PQ? RateQuantity { get; set; }

    [XmlElement("maxDoseQuantity")]
    public RTO_PQ_PQ? MaxDoesQuantity { get; set; }

    [XmlElement("administrationUnitCode")]
    public CE? AdministrationUnitCode { get; set; }

    [XmlElement("consumable")]
    public Consumable Consumable { get; set; }

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