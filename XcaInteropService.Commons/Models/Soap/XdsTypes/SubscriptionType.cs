using System.ComponentModel;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class SubscriptionType : RegistryObjectType
{
    public SubscriptionType()
    {
        NotificationInterval = "P1D";
    }

    [XmlElement("Action", typeof(ActionType), Order = 0)]
    [XmlElement("NotifyAction", typeof(NotifyActionType), Order = 0)]
    public ActionType[] Items;

    [XmlAttribute(AttributeName = "selector", DataType = "anyURI")]
    public string Selector;

    [XmlAttribute(AttributeName = "startTime")]
    public DateTime StartTime;

    [XmlIgnore]
    public bool startTimeSpecified;

    [XmlAttribute(AttributeName = "endTime")]
    public DateTime EndTime;

    [XmlIgnore]
    public bool endTimeSpecified;

    [XmlAttribute(AttributeName = "notificationInterval", DataType = "duration")]
    [DefaultValue("P1D")]
    public string NotificationInterval;
}
