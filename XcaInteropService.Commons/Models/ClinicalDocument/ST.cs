using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ST : ANY
{
    [XmlAttribute("representation")]
    public string? Representation { get; set; }

    [XmlAttribute("mediaType")]
    public string? MediaType { get; set; }

    [XmlAttribute("language")]
    public string? Language { get; set; }

    [XmlText]
    public string? Value { get; set; }
}