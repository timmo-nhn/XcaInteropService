using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.Hl7.V3;

public class Hl7v3MessageBase
{
    [XmlAttribute("ITSVersion", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public string? ItsVersion { get; set; }

    [XmlElement("id", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public II? Id { get; set; }

    [XmlElement("creationTime", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public TS? CreationTime { get; set; }

    [XmlElement("interactionId", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public II? InteractionId { get; set; }

    [XmlElement("processingCode", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public CD? ProcessingCode { get; set; }

    [XmlElement("processingModeCode", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public CD? ProcessingModeCode { get; set; }

    [XmlElement("acceptAckCode", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public CD? AcceptAckCode { get; set; }

}