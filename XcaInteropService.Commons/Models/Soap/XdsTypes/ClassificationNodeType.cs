using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class ClassificationNodeType : RegistryObjectType
{
    [XmlElement("ClassificationNode", Order = 0)]
    public ClassificationNodeType[] ClassificationNode;

    [XmlAttribute(AttributeName = "parent", DataType = "anyURI")]
    public string Parent;

    [XmlAttribute(AttributeName = "code")]
    public string Code;

    [XmlAttribute(AttributeName = "path")]
    public string Path;
}
