using System.Xml.Serialization;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[XmlInclude(typeof(ANY))]
[XmlInclude(typeof(BL))]
[XmlInclude(typeof(ED))]
[XmlInclude(typeof(ST))]
[XmlInclude(typeof(CD))]
[XmlInclude(typeof(CV))]
[XmlInclude(typeof(CE))]
[XmlInclude(typeof(SC))]
[XmlInclude(typeof(II))]
[XmlInclude(typeof(TEL))]
[XmlInclude(typeof(AD))]
[XmlInclude(typeof(EN))]
[XmlInclude(typeof(INT))]
[XmlInclude(typeof(REAL))]
[XmlInclude(typeof(PQ))]
[XmlInclude(typeof(MO))]
[XmlInclude(typeof(TS))]
[XmlInclude(typeof(IVL_PQ))]
[XmlInclude(typeof(IVL_TS))]
[XmlInclude(typeof(PIVL_TS))]
[XmlInclude(typeof(EIVL_TS))]
[XmlInclude(typeof(SXPR_TS))]
[XmlInclude(typeof(RTO_PQ_PQ))]
public class ANY
{
    [XmlAttribute("nullFlavor")]
    public string? NullFlavor { get; set; }
}