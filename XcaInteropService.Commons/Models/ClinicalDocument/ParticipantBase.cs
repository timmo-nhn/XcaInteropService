using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("participant", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ParticipantBase
{
    [XmlAttribute("nullFlavor")]
    public string? NullFlavor { get; set; }

    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlAttribute("contextControlCode")]
    public string? ContextControlCode { get; set; }

    [XmlElement("realmCode")]
    public List<CS>? RealmCode { get; set; }

    [XmlElement("typeId")]
    public II? TypeId { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("time")]
    public IVL_TS? Time { get; set; }

    // Properties specific to Participant1
    [XmlElement("functionCode")]
    public CE? FunctionCode { get; set; }

    [XmlElement("associatedEntity")]
    public AssociatedEntity? AssociatedEntity { get; set; }

    // Properties specific to Participant2
    [XmlElement("functionCode", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public CE? SdtcFunctionCode { get; set; }

    [XmlElement("awarenessCode")]
    public CE? AwarenessCode { get; set; }

    [XmlElement("participantRole")]
    public ParticipantRole? ParticipantRole { get; set; }

    // Conditional serialization for functionCode (for Participant1)
    public bool ShouldSerializeFunctionCode()
    {
        return FunctionCode != null;
    }

    // Conditional serialization for sdtcFunctionCode (for Participant2)
    public bool ShouldSerializeSdtcFunctionCode()
    {
        return SdtcFunctionCode != null;
    }

    // Conditional serialization for associatedEntity (for Participant1)
    public bool ShouldSerializeAssociatedEntity()
    {
        return AssociatedEntity != null;
    }

    // Conditional serialization for awarenessCode and participantRole (for Participant2)
    public bool ShouldSerializeAwarenessCode()
    {
        return AwarenessCode != null;
    }

    public bool ShouldSerializeParticipantRole()
    {
        return ParticipantRole != null;
    }
}

public class Participant1 : ParticipantBase { }
public class Participant2 : ParticipantBase { }
