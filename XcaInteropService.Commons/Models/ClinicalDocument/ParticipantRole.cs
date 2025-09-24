using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("participantRole", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ParticipantRole
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("id")]
    public List<II>? Id { get; set; }

    [XmlElement("identifiedBy", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public List<IdentifiedBy>? SdtcIdentifiedBy { get; set; }

    [XmlElement("code")]
    public CE? Code { get; set; }

    [XmlElement("addr")]
    public List<AD>? Address { get; set; }

    [XmlElement("telecom")]
    public List<TEL>? Telecom { get; set; }

    [XmlElement("playingDevice")]
    public Device? ScopingEntity { get; set; }

    [XmlElement("playingEntity")]
    public PlayingEntity? PlayingEntity { get; set; }

    [XmlElement("scopingEntity")]
    public Entity? PlayingDevice { get; set; }
}