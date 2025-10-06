using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[XmlType]
public class DescribedValueSetType
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlAttribute("displayName")]
    public string DisplayName { get; set; }

    [XmlAttribute("version")]
    public string Version { get; set; }

    [XmlElement]
    public ConceptListType ConceptList { get; set; }

    [XmlElement]
    public string? Source { get; set; }

    [XmlElement]
    public string? Purpose { get; set; }

    [XmlElement]
    public string? Definition { get; set; }

    [XmlElement]
    public string? Type { get; set; }

    [XmlElement]
    public string? Binding { get; set; }

    [XmlElement]
    public string? Status { get; set; }

    [XmlIgnore]
    public DateTime EffectiveDate { get; set; }

    [XmlElement("EffectiveDate")]
    public string EffectiveDateString
    {
        get { return EffectiveDate.ToString(Constants.Hl7.Dtm.DtmFhirIsoDateFormat); }
        set { EffectiveDate = DateTime.Parse(value); }
    }

    [XmlIgnore]
    public DateTime ExpirationDate { get; set; }

    [XmlElement("ExpirationDate")]
    public string ExpirationDateString
    {
        get { return ExpirationDate.ToString(Constants.Hl7.Dtm.DtmFhirIsoDateFormat); }
        set { ExpirationDate = DateTime.Parse(value); }
    }

    [XmlIgnore]
    public DateTime CreationDate { get; set; }

    [XmlElement("CreationDate")]
    public string CreationDateString
    {
        get { return CreationDate.ToString(Constants.Hl7.Dtm.DtmFhirIsoDateFormat); }
        set { CreationDate = DateTime.Parse(value); }
    }

    [XmlIgnore]
    public DateTime RevisionDate { get; set; }

    [XmlElement("RevisionDate")]
    public string RevisionDateString
    {
        get { return RevisionDate.ToString(Constants.Hl7.Dtm.DtmFhirIsoDateFormat); }
        set { RevisionDate = DateTime.Parse(value); }
    }

    [XmlElement]
    public List<GroupType>? Group { get; set; }
}