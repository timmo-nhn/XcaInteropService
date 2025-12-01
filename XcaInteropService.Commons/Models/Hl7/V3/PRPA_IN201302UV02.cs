using System.Xml;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

namespace XcaInteropService.Commons.Models.Hl7.V3;

/// <summary>
/// ITI-44 request (Revise patient)
/// </summary>
[Serializable]
[XmlRoot("PRPA_IN201302UV02", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class PRPA_IN201302UV02 : Hl7v3MessageBase
{
    [XmlElement("receiver", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public CFReceiver? Receiver { get; set; }

    [XmlElement("sender", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public CFSender? Sender { get; set; }

    [XmlElement("controlActProcess", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public CFControlActProcess? ControlActProcess { get; set; }
}