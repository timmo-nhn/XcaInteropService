using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType("component", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Component : InfrastructureRoot
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

    [XmlIgnore]
    public NonXmlBody? NonXmlBody
    {
        get => Item as NonXmlBody;
        set => Item = value;
    }

    [XmlIgnore]
    public StructuredBody? StructuredBody
    {
        get => Item as StructuredBody;
        set => Item = value;
    }

    [XmlIgnore]
    public Section? Section
    {
        get => Item as Section;
        set => Item = value;
    }

    [XmlElement("nonXMLBody", typeof(NonXmlBody))]
    [XmlElement("structuredBody", typeof(StructuredBody))]
    [XmlElement("section", typeof(Section))]
    [XmlElement("component", typeof(Component))]
    public object? Item { get; set; }

    [XmlElement("text")]
    public ED? Text { get; set; }
}

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ComponentSection : InfrastructureRoot
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("section", typeof(Section))]
    [XmlElement("component", typeof(Component))]
    public object? Item { get; set; }

}

public class OrganizerComponent : InfrastructureRoot
{
    [XmlElement("sequenceNumber")]
    public INT? SequenceNumber { get; set; }

    [XmlElement("priorityNumber")]
    public INT? PriorityNumber { get; set; }

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