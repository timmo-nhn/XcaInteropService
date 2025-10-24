
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfDevice", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFDevice
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlAttribute("determinerCode")]
    public string? DeterminerCode { get; set; }

    [XmlElement("id")]
    public List<II>? Id { get; set; }

    [XmlElement("telecom")]
    public List<TEL>? Telecom { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("code")]
    public CE? Code { get; set; }

    [XmlElement("manufacturerModelName")]
    public SC? ManufacturerModelName { get; set; }

    [XmlElement("softwareName")]
    public SC? SoftwareName { get; set; }

}