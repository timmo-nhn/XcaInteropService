using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class SpecificationLinkType : RegistryObjectType
{
    [XmlElement(Order = 0)]
    public InternationalStringType UsageDescription;

    [XmlElement("UsageParameter", Order = 1)]
    public string[] UsageParameter;

    [XmlAttribute(AttributeName = "serviceBinding", DataType = "anyURI")]
    public string ServiceBinding;

    [XmlAttribute(AttributeName = "specificationObject", DataType = "anyURI")]
    public string SpecificationObject;
}
