using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Svs)]
public class ConceptType
{
    [XmlAttribute(AttributeName = "code")]
    public string Code = string.Empty;

    [XmlAttribute(AttributeName = "codeSystemName")]
    public string CodeSystemName = string.Empty;

    [XmlAttribute(AttributeName = "displayName")]
    public string DisplayName = string.Empty;
}