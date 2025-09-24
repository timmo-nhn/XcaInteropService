using System.ComponentModel;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Query)]
public class ResponseOptionType
{
    public ResponseOptionType()
    {
        ReturnType = ResponseOptionTypeReturnType.RegistryObject;
        ReturnComposedObjects = false;
    }

    [XmlAttribute(AttributeName = "returnType")]
    [DefaultValue(ResponseOptionTypeReturnType.RegistryObject)]
    public ResponseOptionTypeReturnType ReturnType { get; set; }

    [XmlAttribute(AttributeName = "returnComposedObjects")]
    [DefaultValue(false)]
    public bool ReturnComposedObjects { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Xds.Namespaces.Query)]
public enum ResponseOptionTypeReturnType
{
    LeafClass,
    ObjectRef,
    RegistryObject,
    LeafClassWithRepositoryItem
}
