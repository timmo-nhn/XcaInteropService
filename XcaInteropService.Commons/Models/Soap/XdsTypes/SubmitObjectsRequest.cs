using System.Runtime.Serialization;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[KnownType(typeof(RegistryPackageType))]
[KnownType(typeof(ExtrinsicObjectType))]
[KnownType(typeof(AssociationType))]
[XmlType(AnonymousType = true, Namespace = Constants.Xds.Namespaces.Lcm)]
public class SubmitObjectsRequest : RegistryRequestType
{
    [XmlArray(Namespace = Constants.Xds.Namespaces.Rim, Order = 0)]
    [XmlArrayItem("Identifiable", IsNullable = false)]
    [XmlArrayItem("RegistryObject", typeof(RegistryObjectType), IsNullable = false)]
    [XmlArrayItem("Notification", typeof(NotificationType), IsNullable = false)]
    [XmlArrayItem("AdhocQuery", typeof(AdhocQueryType), IsNullable = false)]
    [XmlArrayItem("Subscription", typeof(SubscriptionType), IsNullable = false)]
    [XmlArrayItem("Federation", typeof(FederationType), IsNullable = false)]
    [XmlArrayItem("Registry", typeof(RegistryType), IsNullable = false)]
    [XmlArrayItem("Person", typeof(PersonType), IsNullable = false)]
    [XmlArrayItem("User", typeof(UserType), IsNullable = false)]
    [XmlArrayItem("SpecificationLink", typeof(SpecificationLinkType), IsNullable = false)]
    [XmlArrayItem("ServiceBinding", typeof(ServiceBindingType), IsNullable = false)]
    [XmlArrayItem("Service", typeof(ServiceType), IsNullable = false)]
    [XmlArrayItem("RegistryPackage", typeof(RegistryPackageType), IsNullable = false)]
    [XmlArrayItem("Organization", typeof(OrganizationType), IsNullable = false)]
    [XmlArrayItem("ExtrinsicObject", typeof(ExtrinsicObjectType), IsNullable = false)]
    [XmlArrayItem("ExternalLink", typeof(ExternalLinkType), IsNullable = false)]
    [XmlArrayItem("ClassificationScheme", typeof(ClassificationSchemeType), IsNullable = false)]
    [XmlArrayItem("ClassificationNode", typeof(ClassificationNodeType), IsNullable = false)]
    [XmlArrayItem("AuditableEvent", typeof(AuditableEventType), IsNullable = false)]
    [XmlArrayItem("Association", typeof(AssociationType), IsNullable = false)]
    [XmlArrayItem("ExternalIdentifier", typeof(ExternalIdentifierType), IsNullable = false)]
    [XmlArrayItem("Classification", typeof(ClassificationType), IsNullable = false)]
    [XmlArrayItem("ObjectRef", typeof(ObjectRefType), IsNullable = false)]
    public IdentifiableType[] RegistryObjectList;
}
