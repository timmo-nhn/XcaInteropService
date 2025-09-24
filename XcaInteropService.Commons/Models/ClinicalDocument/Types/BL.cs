using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class BL : ANY
{
    [XmlIgnore]
    private bool? _value;

    [XmlAttribute("value")]
    public string? Value
    {
        get => _value.HasValue ? _value.ToString().ToLowerInvariant() : null;
        set => _value = string.IsNullOrEmpty(value) ? null : bool.Parse(value);
    }

}
