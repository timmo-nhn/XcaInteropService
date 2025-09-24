using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class TEL : ANY
{
    [XmlAttribute("value")]
    public string? Value { get; set; }

    [XmlAttribute("use")]
    public string? Use { get; set; }

    [XmlElement("useablePeriod")]
    public List<IVL_TS>? UseablePeriod { get; set; }
}
