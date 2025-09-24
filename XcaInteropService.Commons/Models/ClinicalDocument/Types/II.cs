using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class II : ANY
{
    [XmlAttribute("root")]
    public string Root { get; set; }

    [XmlAttribute("extension")]
    public string Extension { get; set; }
}
