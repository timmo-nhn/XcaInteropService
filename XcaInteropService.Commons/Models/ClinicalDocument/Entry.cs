using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("entry", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Entry : InfrastructureRoot
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlIgnore]
    private bool? _contextConductionInd;

    [XmlAttribute("contextConductionInd")]
    public string? ContextConductionInd
    {
        get => _contextConductionInd.HasValue ? _contextConductionInd.ToString().ToLowerInvariant() : null;
        set => _contextConductionInd = string.IsNullOrEmpty(value) ? null : bool.Parse(value);
    }


    // The following property models the choice of types (one of the types can be set)
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