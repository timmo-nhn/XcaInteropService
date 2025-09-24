using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[XmlInclude(typeof(IVL_TS))]
[XmlInclude(typeof(EIVL_TS))]
[XmlInclude(typeof(PIVL_TS))]
[XmlInclude(typeof(SXPR_TS))]
[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class SXCM_TS : TS
{
    [XmlAttribute("operator")]
    public string? Operator { get; set; }
}
