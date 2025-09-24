using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class AuditableEventType : RegistryObjectType
{
    [XmlElement(ElementName = "affectedObjects", Order = 0)]
    public ObjectRefList AffectedObjects;

    [XmlAttribute(AttributeName = "eventType", DataType = "anyURI")]
    public string EventType;

    [XmlAttribute(AttributeName = "timestamp")]
    public DateTime Timestamp;

    [XmlAttribute(AttributeName = "user", DataType = "anyURI")]
    public string User;

    [XmlAttribute(AttributeName = "requestId", DataType = "anyURI")]
    public string RequestId;
}
