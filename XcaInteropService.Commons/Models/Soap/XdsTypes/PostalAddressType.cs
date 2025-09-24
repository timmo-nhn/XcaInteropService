using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class PostalAddressType
{
    [XmlAttribute(AttributeName = "city")]
    public string City;

    [XmlAttribute(AttributeName = "country")]
    public string Country;

    [XmlAttribute(AttributeName = "postalCode")]
    public string PostalCode;

    [XmlAttribute(AttributeName = "stateOrProvince")]
    public string StateOrProvince;

    [XmlAttribute(AttributeName = "street")]
    public string Street;

    [XmlAttribute(AttributeName = "streetNumber")]
    public string StreetNumber;
}
