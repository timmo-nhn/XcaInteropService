using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class TelephoneNumberType
{
    [XmlAttribute(AttributeName = "areaCode")]
    public string AreaCode;

    [XmlAttribute(AttributeName = "countryCode")]
    public string CountryCode;

    [XmlAttribute(AttributeName = "extension")]
    public string Extension;

    [XmlAttribute(AttributeName = "number")]
    public string Number;

    [XmlAttribute(AttributeName = "phoneType")]
    public string PhoneType;

}
