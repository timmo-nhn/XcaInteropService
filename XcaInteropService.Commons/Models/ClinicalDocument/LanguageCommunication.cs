using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("languageCommunication", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class LanguageCommunication
{
    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("languageCode")]
    public CS? LanguageCode { get; set; }

    [XmlElement("modeCode")]
    public CE? ModeCode { get; set; }

    [XmlElement("proficiencyLevelCode")]
    public CE? ProficiencyLevelCode { get; set; }

    [XmlElement("preferenceInd")]
    public BL? PreferenceInd { get; set; }
}