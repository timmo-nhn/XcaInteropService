using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Xds.Namespaces.Rs)]
public partial class RegistryErrorType
{
    public RegistryErrorType() { }

    [XmlAttribute(AttributeName = "codeContext")]
    public string CodeContext;

    [XmlAttribute(AttributeName = "errorCode")]
    public string ErrorCode;

    [XmlAttribute(AttributeName = "severity")]
    public string Severity;

    [XmlAttribute(AttributeName = "location")]
    public string Location;

    [XmlText]
    public string Value;
}
