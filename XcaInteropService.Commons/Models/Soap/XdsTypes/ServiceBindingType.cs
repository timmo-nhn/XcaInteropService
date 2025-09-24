using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class ServiceBindingType : RegistryObjectType
{
    [XmlElement("SpecificationLink", Order = 0)]
    public SpecificationLinkType[] SpecificationLink;

    [XmlAttribute(AttributeName = "service", DataType = "anyURI")]
    public string Service;

    [XmlAttribute(AttributeName = "accessURI", DataType = "anyURI")]
    public string AccessUri;

    [XmlAttribute(AttributeName = "targetBinding", DataType = "anyURI")]
    public string TargetBinding;
}
