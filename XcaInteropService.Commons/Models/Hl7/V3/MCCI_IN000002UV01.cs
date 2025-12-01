using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

namespace XcaInteropService.Commons.Models.Hl7.V3;

/// <summary>
/// Acknowledgement
/// </summary>
[Serializable]
[XmlRoot("MCCI_IN000002UV01", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class MCCI_IN000002UV01 : Hl7v3MessageBase
{
    [XmlElement("receiver")]
    public CFReceiver? Receiver { get; set; }

    [XmlElement("sender")]
    public CFSender? Sender { get; set; }

    [XmlElement("acknowledgement")]
    public CFAcknowledgement? Acknowledgement { get; set; }
}
