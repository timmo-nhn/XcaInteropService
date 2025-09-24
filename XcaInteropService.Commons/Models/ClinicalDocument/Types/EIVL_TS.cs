using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class EIVL_TS : SXCM_TS
{
    [XmlElement("event")]
    public CE? Event { get; set; }

    [XmlElement("offset")]
    public IVL_PQ? Offset { get; set; }
}