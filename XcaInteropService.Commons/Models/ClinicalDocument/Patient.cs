using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("patient", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Patient
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlAttribute("determinerCode")]
    public string? DeterminerCode { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("id")]
    public II? Id { get; set; }

    [XmlElement("name")]
    public List<PN>? Name { get; set; }

    [XmlElement("administrativeGenderCode")]
    public CE? AdministrativeGenderCode { get; set; }

    [XmlElement("birthTime")]
    public TS? BirthTime { get; set; }

    [XmlElement("deceasedInd", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public BL? SdtcDeceasedInd { get; set; }

    [XmlElement("deceasedTime", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public TS? sdtcDeceasedTime { get; set; }

    [XmlElement("multipleBirthInd", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public BL? SdtcMultipleBirthInd { get; set; }

    [XmlElement("multipleBirthOrderNumber", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public BL? SdtcMultipleBirthOrderNumber { get; set; }

    [XmlElement("maritalStatusCode")]
    public CE? MaritalStatusCode { get; set; }

    [XmlElement("religiousAffiliationCode")]
    public CE? ReligiousAffiliationCode { get; set; }

    [XmlElement("raceCode")]
    public CE? RaceCode { get; set; }

    [XmlElement("raceCode", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public List<CE>? SdtcRaceCode { get; set; }

    [XmlElement("ethnicGroupCode")]
    public CE? EthnicGroupCode { get; set; }

    [XmlElement("ethnicGroupCode", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public List<CE>? SdtcEthnicGroupCode { get; set; }

    [XmlElement("guardian")]
    public List<Guardian>? Guardian { get; set; }

    [XmlElement("birthplace")]
    public BirthPlace? BirthPlace { get; set; }

    [XmlElement("languageCommunication")]
    public List<LanguageCommunication>? LanguageCommunication { get; set; }
}