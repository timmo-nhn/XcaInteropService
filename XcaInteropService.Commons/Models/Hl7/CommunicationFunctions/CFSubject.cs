using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;

[Serializable]
[XmlType("cfSubject", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class CFSubject
{
    [XmlAttribute("realmCode")]
    public string RealmCode { get; set; }

    [XmlAttribute("typeCode")]
    public string TypeCode { get; set; } = "SBJ";

    [XmlElement("registrationEvent")]
    public CFRegistrationEvent RegistrationEvent { get; set; }
}
