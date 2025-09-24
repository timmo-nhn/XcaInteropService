using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[XmlInclude(typeof(NotificationType))]
[XmlInclude(typeof(AdhocQueryType))]
[XmlInclude(typeof(SubscriptionType))]
[XmlInclude(typeof(FederationType))]
[XmlInclude(typeof(RegistryType))]
[XmlInclude(typeof(PersonType))]
[XmlInclude(typeof(UserType))]
[XmlInclude(typeof(SpecificationLinkType))]
[XmlInclude(typeof(ServiceBindingType))]
[XmlInclude(typeof(ServiceType))]
[XmlInclude(typeof(RegistryPackageType))]
[XmlInclude(typeof(OrganizationType))]
[XmlInclude(typeof(ExtrinsicObjectType))]
[XmlInclude(typeof(ExternalLinkType))]
[XmlInclude(typeof(ClassificationSchemeType))]
[XmlInclude(typeof(ClassificationNodeType))]
[XmlInclude(typeof(AuditableEventType))]
[XmlInclude(typeof(AssociationType))]
[XmlInclude(typeof(ExternalIdentifierType))]
[XmlInclude(typeof(ClassificationType))]

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class RegistryObjectType : IdentifiableType
{
    [XmlElement(Order = 0)]
    public InternationalStringType Name;

    [XmlElement(Order = 1)]
    public InternationalStringType Description;

    [XmlElement(Order = 2)]
    public VersionInfoType VersionInfo;

    [XmlElement("Classification", Order = 3)]
    public ClassificationType[] Classification;

    [XmlElement("ExternalIdentifier", Order = 4)]
    public ExternalIdentifierType[] ExternalIdentifier;

    [XmlAttribute(AttributeName = "lid", DataType = "anyURI")]
    public string Lid;

    [XmlAttribute(AttributeName = "objectType", DataType = "anyURI")]
    public string ObjectType;

    [XmlAttribute(AttributeName = "status", DataType = "anyURI")]
    public string Status;

    public ClassificationType[] GetClassifications(string classificationScheme)
    {
        return Classification.Where(cl => cl.ClassificationScheme == classificationScheme).ToArray();
    }
    public ClassificationType? GetFirstClassification(string classificationScheme)
    {
        return Classification.FirstOrDefault(cl => cl.ClassificationScheme == classificationScheme);
    }

    public ExternalIdentifierType[] GetExternalIdentifiers(string identificationScheme)
    {
        return ExternalIdentifier.Where(cl => cl.IdentificationScheme == identificationScheme).ToArray();
    }
    public ExternalIdentifierType? GetFirstExternalIdentifier(string identificationScheme)
    {
        return ExternalIdentifier.FirstOrDefault(cl => cl.IdentificationScheme == identificationScheme);
    }

}
