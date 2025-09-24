using System.ComponentModel;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class RegistryType : RegistryObjectType
{
    public RegistryType()
    {
        ReplicationSyncLatency = "P1D";
        CatalogingLatency = "P1D";
        ConformanceProfile = RegistryTypeConformanceProfile.registryLite;
    }

    [XmlAttribute(AttributeName = "operator", DataType = "anyURI")]
    public string Operator;

    [XmlAttribute(AttributeName = "specificationVersion")]
    public string SpecificationVersion;

    [XmlAttribute(AttributeName = "replicationSyncLatency", DataType = "duration")]
    [DefaultValue("P1D")]
    public string ReplicationSyncLatency;

    [XmlAttribute(AttributeName = "catalogingLatency", DataType = "duration")]
    [DefaultValue("P1D")]
    public string CatalogingLatency;

    [XmlAttribute(AttributeName = "conformanceProfile")]
    [DefaultValue(RegistryTypeConformanceProfile.registryLite)]
    public RegistryTypeConformanceProfile ConformanceProfile;
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Xds.Namespaces.Rim)]
public enum RegistryTypeConformanceProfile
{
    registryFull,
    registryLite
}
