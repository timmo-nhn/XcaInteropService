using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlInclude(typeof(IVL_TS))]
[XmlInclude(typeof(EIVL_TS))]
[XmlInclude(typeof(PIVL_TS))]
[XmlInclude(typeof(SXPR_TS))]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class SXPR_TS : SXCM_TS
{
    [XmlElement("comp")]
    public List<SXCM_TS> Comp { get; set; } = new();
}
