using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class ExternalLinkType : RegistryObjectType
{
    [XmlAttribute(AttributeName = "externalURI", DataType = "anyURI")]
    public string ExternalUri;
}
