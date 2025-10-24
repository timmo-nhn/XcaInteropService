using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfPatientPerson", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFPatientPerson : Patient
{
    [XmlElement("statusCode")]
    public CE? StatusCode { get; set; }

    [XmlElement("addr")]
    public AD? Address { get; set; }

    [XmlElement("asOtherIDs")]
    public List<AssociatedEntity>? asOtherIds { get; set; }
}