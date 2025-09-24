using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ENXP : ST
{
    [XmlText]
    public string? Value { get; set; }

    [XmlAttribute("partType")]
    public string? PartType { get; set; }

    [XmlAttribute("qualifier")]
    public string? QualifierRaw { get; set; }

    [XmlIgnore]
    public List<string> Qualifier
    {
        get => QualifierRaw?.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList() ?? new();
        set => QualifierRaw = string.Join(" ", value);
    }
}
