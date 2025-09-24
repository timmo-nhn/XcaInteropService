using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("performer", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class PerformerBase
{
    [XmlAttribute("nullFlavor")]
    public string? NullFlavor { get; set; }

    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("realmCode")]
    public List<CS>? RealmCode { get; set; }

    [XmlElement("typeId")]
    public II? TypeId { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("functionCode", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public CE? SdtcFunctionCode { get; set; }

    [XmlElement("functionCode")]
    public CD? FunctionCode { get; set; }

    [XmlElement("time")]
    public IVL_TS? Time { get; set; }

    [XmlElement("modeCode")]
    public CE? ModeCode { get; set; }

    [XmlElement("assignedEntity")]
    public AssignedEntity AssignedEntity { get; set; }

    public bool ShouldSerializeFunctionCode()
    {
        return FunctionCode != null;
    }

    public bool ShouldSerializeSdtcFunctionCode()
    {
        return SdtcFunctionCode != null;
    }
}

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Performer1 : PerformerBase
{
}

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Performer2 : PerformerBase
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }
}
