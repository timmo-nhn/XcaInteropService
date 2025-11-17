using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfPatient", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFPatient
{
    [XmlAttribute("classCode", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public string? ClassCode { get; set; }

    [XmlElement("id", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public List<II>? Id { get; set; }

    [XmlElement("statusCode", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public CE? StatusCode { get; set; }

    [XmlElement("patientPerson", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public CFPatientPerson? Patient { get; set; }

    [XmlElement("providerOrganization", Namespace = Constants.Xds.Namespaces.Hl7V3)]
    public CFProviderOrganization? ProviderOrganization { get; set; }
}