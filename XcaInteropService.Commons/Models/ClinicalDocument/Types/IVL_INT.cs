using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class IVL_INT : ANY
{
    [XmlAttribute("value")]
    public string? Value { get; set; }

    [XmlAttribute("operator")]
    public string? Operator { get; set; }

    [XmlElement("low")]
    public IVXB_INT? Low { get; set; }

    [XmlElement("center")]
    public INT? Center { get; set; }

    [XmlElement("width")]
    public INT Width { get; set; }

    [XmlElement("high")]
    public IVXB_INT? High { get; set; }
}