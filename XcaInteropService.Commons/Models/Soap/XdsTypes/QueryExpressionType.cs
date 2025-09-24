using System.Xml;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class QueryExpressionType
{
    [XmlText]
    [XmlAnyElement(Order = 0)]
    public XmlNode[] Any;


    [XmlAttribute(AttributeName = "queryLanguage", DataType = "anyURI")]
    public string QueryLanguage;
}
