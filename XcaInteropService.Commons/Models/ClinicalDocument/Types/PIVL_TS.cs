using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class PIVL_TS : SXCM_TS
{
    [XmlElement("phase")]
    public IVL_TS? Phase { get; set; }

    [XmlElement("period")]
    public PQ? Period { get; set; }

    [XmlAttribute("alignment")]
    public string? Alignment { get; set; }

    [XmlIgnore]
    private bool? _institutionSpecified;

    [XmlAttribute("institutionSpecified")]
    public string? InstitutionSpecified
    {
        get => _institutionSpecified.HasValue ? _institutionSpecified.ToString().ToLowerInvariant() : null;
        set => _institutionSpecified = string.IsNullOrEmpty(value) ? null : bool.Parse(value);
    }
}
