using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class EN : ANY
{
    [XmlAttribute("user")]
    public string? Use { get; set; }

    [XmlElement("delimiter")]
    public List<ENXP>? Delimiter { get; set; }

    [XmlElement("family")]
    public List<ENXP>? Family { get; set; }

    [XmlElement("given")]
    public List<ENXP>? Given { get; set; }

    [XmlElement("prefix")]
    public List<ENXP>? Prefix { get; set; }

    [XmlElement("suffix")]
    public List<ENXP>? Suffix { get; set; }

    [XmlText]
    public string? XmlText { get; set; }
}