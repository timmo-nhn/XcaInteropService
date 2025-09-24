using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("entryRelationship", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class EntryRelationship : InfrastructureRoot
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlIgnore]
    private bool? _inversionInd;

    [XmlAttribute("inversionInd")]
    public string? InversionInd
    {
        get => _inversionInd.HasValue ? _inversionInd.ToString().ToLowerInvariant() : null;
        set => _inversionInd = string.IsNullOrEmpty(value) ? null : bool.Parse(value);
    }

    [XmlIgnore]
    private bool? _contextConductionInd;

    [XmlAttribute("contextConductionInd")]
    public string? ContextConductionInd
    {
        get => _contextConductionInd.HasValue ? _contextConductionInd.ToString().ToLowerInvariant() : null;
        set => _contextConductionInd = string.IsNullOrEmpty(value) ? null : bool.Parse(value);
    }

    private bool? _negationInd;

    [XmlAttribute("negationInd")]
    public string? NegationInd
    {
        get => _negationInd.HasValue ? _negationInd.ToString().ToLowerInvariant() : null;
        set => _negationInd = string.IsNullOrEmpty(value) ? null : bool.Parse(value);
    }

    [XmlElement("sequenceNumber")]
    public INT? SequenceNumber { get; set; }

    [XmlElement("seperatableInd")]
    public BL? SeperatableInd { get; set; }

    [XmlElement("act", typeof(Act))]
    [XmlElement("encounter", typeof(Encounter))]
    [XmlElement("observation", typeof(Observation))]
    [XmlElement("observationMedia", typeof(ObservationMedia))]
    [XmlElement("organizer", typeof(Organizer))]
    [XmlElement("procedure", typeof(Procedure))]
    [XmlElement("regionOfInterest", typeof(RegionOfInterest))]
    [XmlElement("substanceAdministration", typeof(SubstanceAdministration))]
    [XmlElement("supply", typeof(Supply))]
    public EntryItemBase? EntryItem { get; set; }
}