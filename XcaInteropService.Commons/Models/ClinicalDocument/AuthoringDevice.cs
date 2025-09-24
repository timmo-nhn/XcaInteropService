
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("authoringDevice", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class AuthoringDevice
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlAttribute("determinerCode")]
    public string? DeterminerCode { get; set; }


    [XmlElement("manufacturerModelName")]
    public SC? ManufacturerModelName { get; set; }

    [XmlElement("softwareName")]
    public SC? SoftwareName { get; set; }

    [XmlElement("asMaintainedEntity")]
    public List<MaintainedEntity>? AsMaintainedEntity { get; set; }
}