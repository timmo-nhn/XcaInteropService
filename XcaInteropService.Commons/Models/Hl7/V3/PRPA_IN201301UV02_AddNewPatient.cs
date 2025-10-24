using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;
using XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

namespace XcaInteropService.Commons.Models.Hl7.V3;

[Serializable]
[XmlRoot("PRPA_IN201301UV02", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class PRPA_IN201301UV02_AddNewPatient
{
    [XmlElement("id")]
    public II? Id { get; set; }

    [XmlElement("creationTime")]
    public TS? CreationTime { get; set; }

    [XmlElement("interactionId")]
    public II? InteractionId { get; set; }

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

    [XmlElement("controlActProcess")]
    public CFControlActProcess? ControlActProcess { get; set; }
}