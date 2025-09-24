using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CD : ANY
{
    [XmlAttribute("code")]
    public string? Code { get; set; }

    [XmlAttribute("codeSystem")]
    public string? CodeSystem { get; set; }

    [XmlAttribute("codeSystemName")]
    public string? CodeSystemName { get; set; }

    [XmlAttribute("codeSystemVersion")]
    public string? CodeSystemVersion { get; set; }

    [XmlAttribute("displayName")]
    public string? DisplayName { get; set; }

    [XmlAttribute("valueSet", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public string? SdtcValueSet { get; set; }

    [XmlAttribute("valueSetVersion", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public string? SdtcValueSetVersion { get; set; }

    [XmlElement("originalText")]
    public ED? OriginalText { get; set; }

    [XmlElement("qualifier")]
    public List<CR>? Qualifier { get; set; }

    [XmlElement("translation")]
    public List<CD>? Translation { get; set; }
}