using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class IVXB_TS : TS
{
    [XmlIgnore]
    private bool? _inclusive;

    [XmlAttribute("inclusive")]
    public string? Inclusive
    {
        get => _inclusive.HasValue ? _inclusive.ToString().ToLowerInvariant() : null;
        set => _inclusive = string.IsNullOrEmpty(value) ? null : bool.Parse(value);
    }
}