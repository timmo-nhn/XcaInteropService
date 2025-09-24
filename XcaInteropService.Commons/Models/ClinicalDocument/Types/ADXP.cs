using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ADXP : ST
{
    [XmlAttribute("partType")]
    public string? PartType { get; set; }

    [XmlText]
    public string? Value { get; set; }

}