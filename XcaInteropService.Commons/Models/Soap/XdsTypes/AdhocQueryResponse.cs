using System.ComponentModel;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Xds.Namespaces.Query)]
public partial class AdhocQueryResponse : RegistryResponseType
{
    public AdhocQueryResponse()
    {
        StartIndex = "0";
    }

    // https://gazelle.ihe.net/XDStarClient/rim/RegistryObjectListType.html
    [XmlArray(Namespace = Constants.Xds.Namespaces.Rim, Order = 0)]
    [XmlArrayItem("AdhocQuery", typeof(AdhocQueryType), IsNullable = false)]
    [XmlArrayItem("Identifiable", IsNullable = false)]
    [XmlArrayItem("Association", typeof(AssociationType), IsNullable = false)]
    [XmlArrayItem("AuditableEvent", typeof(AuditableEventType), IsNullable = false)]
    [XmlArrayItem("ClassificationNode", typeof(ClassificationNodeType), IsNullable = false)]
    [XmlArrayItem("ClassificationScheme", typeof(ClassificationSchemeType), IsNullable = false)]
    [XmlArrayItem("Classification", typeof(ClassificationType), IsNullable = false)]
    [XmlArrayItem("ExternalIdentifier", typeof(ExternalIdentifierType), IsNullable = false)]
    [XmlArrayItem("ExternalLink", typeof(ExternalLinkType), IsNullable = false)]
    [XmlArrayItem("ExtrinsicObject", typeof(ExtrinsicObjectType), IsNullable = false)]
    [XmlArrayItem("Federation", typeof(FederationType), IsNullable = false)]
    [XmlArrayItem("Notification", typeof(NotificationType), IsNullable = false)]
    [XmlArrayItem("ObjectRef", typeof(ObjectRefType), IsNullable = false)]
    [XmlArrayItem("Organization", typeof(OrganizationType), IsNullable = false)]
    [XmlArrayItem("RegistryObject", typeof(RegistryObjectType), IsNullable = false)]
    [XmlArrayItem("RegistryPackage", typeof(RegistryPackageType), IsNullable = false)]
    [XmlArrayItem("Registry", typeof(RegistryType), IsNullable = false)]
    [XmlArrayItem("Person", typeof(PersonType), IsNullable = false)]
    [XmlArrayItem("Subscription", typeof(SubscriptionType), IsNullable = false)]
    [XmlArrayItem("SpecificationLink", typeof(SpecificationLinkType), IsNullable = false)]
    [XmlArrayItem("ServiceBinding", typeof(ServiceBindingType), IsNullable = false)]
    [XmlArrayItem("Service", typeof(ServiceType), IsNullable = false)]
    [XmlArrayItem("User", typeof(UserType), IsNullable = false)]
    public IdentifiableType[] RegistryObjectList;

    [XmlAttribute(AttributeName = "startIndex", DataType = "integer")]
    [DefaultValue("0")]
    public string StartIndex;

    [XmlAttribute(AttributeName = "totalResultCount", DataType = "integer")]
    public string TotalResultCount;
}
