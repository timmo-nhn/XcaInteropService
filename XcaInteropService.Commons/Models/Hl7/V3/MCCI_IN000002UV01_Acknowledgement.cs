using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;
using XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

namespace XcaInteropService.Commons.Models.Hl7.V3;

[Serializable]
[XmlType("MCCI_IN000002UV01", Namespace = Constants.Xds.Namespaces.Hl7V3)]
[XmlRoot("MCCI_IN000002UV01", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class MCCI_IN000002UV01_Acknowledgement
{
    [XmlElement("id")]
    public II? Id { get; set; }

    [XmlElement("creationTime")]
    public TS? CreationTime { get; set; }

    [XmlElement("interactionId")]
    public CD? InteractionId { get; set; }

    [XmlElement("processingCode")]
    public CD? ProcessingCode { get; set; }

    [XmlElement("processingModeCode")]
    public CD? ProcessingModeCode { get; set; }

    [XmlElement("acceptAckCode")]
    public CD? AcceptAckCode { get; set; }

    [XmlElement("receiver")]
    public CFReceiver? Receiver { get; set; }

    [XmlElement("sender")]
    public CFSender? Sender { get; set; }

    [XmlElement("acknowledgement")]
    public CFAcknowledgement? Acknowledgement { get; set; }
}
