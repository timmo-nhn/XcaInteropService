using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("legalAuthenticator", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class LegalAuthenticator
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
    public List<II> TemplateId { get; set; }

    [XmlElement("time")]
    public TS Time { get; set; }

    [XmlElement("signatureCode")]
    public CS SignatureCode { get; set; }

    [XmlElement("signatureText", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public ED? SdtcSignatureText { get; set; }

    [XmlElement("assignedEntity")]
    public AssignedEntity AssignedEntity { get; set; }
}