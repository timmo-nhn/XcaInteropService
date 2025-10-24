using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfPatient", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFPatient
{
    [XmlAttribute("classCode")]
    public string? ClassCode { get; set; }

    [XmlElement("id")]
    public List<II>? Id { get; set; }

    [XmlElement("statusCode")]
    public CE StatusCode { get; set; }

    [XmlElement("patientPerson")]
    public CFPatientPerson Patient { get; set; }

    [XmlElement("providerOrganization")]
    public CFProviderOrganization ProviderOrganization { get; set; }
}