using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class PersonNameType
{
    [XmlAttribute(AttributeName = "firstName")]
    public string FirstName;

    [XmlAttribute(AttributeName = "middleName")]
    public string MiddleName;

    [XmlAttribute(AttributeName = "lastName")]
    public string LastName;
}
