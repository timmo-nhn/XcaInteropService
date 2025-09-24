using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("assignedCustodian", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class AssignedCustodian
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("representedCustodianOrganization")]
    public CustodianOrganization RepresentedCustodianOrganization { get; set; }
}