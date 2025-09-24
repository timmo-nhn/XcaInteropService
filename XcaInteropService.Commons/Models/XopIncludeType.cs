using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models;

[Serializable]
[XmlRoot("Include", Namespace = Constants.Soap.Namespaces.XopInclude)]
public partial class IncludeType
{
    [XmlAttribute()]
    public string href { get; set; }
}
