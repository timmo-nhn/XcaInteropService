using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("subjectPerson", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class SubjectPerson
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlAttribute("determinerCode")]
    public string? DeterminerCode { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("name")]
    public List<PN>? Name { get; set; }

    [XmlElement("desc", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public ED? SdtcDesc { get; set; }

    [XmlElement("administrativeGenderCode")]
    public CE? AdministrativeGenderCode { get; set; }

    [XmlElement("birthTime")]
    public TS? BirthTime { get; set; }

    [XmlElement("deceasedInd")]
    public BL? SdtcDeceasedInd { get; set; }

    [XmlElement("deceasedTime")]
    public TS? SdtcDeceasedTime { get; set; }
}