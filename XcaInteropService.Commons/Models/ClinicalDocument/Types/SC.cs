using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;


[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class SC : ST
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
}
