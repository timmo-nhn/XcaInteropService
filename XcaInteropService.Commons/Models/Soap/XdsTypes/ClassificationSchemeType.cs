using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;


[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class ClassificationSchemeType : RegistryObjectType
{

    [XmlElement("ClassificationNode", Order = 0)]
    public ClassificationNodeType[] ClassificationNode;

    [XmlAttribute(AttributeName = "isInternal")]
    public bool IsInternal;

    [XmlAttribute(AttributeName = "nodeType", DataType = "anyURI")]
    public string NodeType;
}
