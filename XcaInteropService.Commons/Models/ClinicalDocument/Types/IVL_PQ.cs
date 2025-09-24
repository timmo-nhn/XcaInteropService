using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class IVL_PQ : ANY
{
    [XmlAttribute("unit")]
    public string? Unit { get; set; }

    [XmlAttribute("value")]
    public string? Value { get; set; }

    [XmlAttribute("operator")]
    public string? Operator { get; set; }

    [XmlElement("low")]
    public IVXB_PQ? Low { get; set; }

    [XmlElement("center")]
    public TS? Center { get; set; }

    [XmlElement("width")]
    public PQ Width { get; set; }

    [XmlElement("high")]
    public IVXB_PQ? High { get; set; }
}
