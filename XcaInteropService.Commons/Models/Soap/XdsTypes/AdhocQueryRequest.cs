using System.ComponentModel;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(AnonymousType = true, Namespace = "urn:oasis:names:tc:ebxml-regrep:xsd:query:3.0")]
[XmlRoot("AdhocQueryRequest", Namespace = "urn:oasis:names:tc:ebxml-regrep:xsd:query:3.0", IsNullable = false)]
public partial class AdhocQueryRequest : RegistryRequestType
{
    public AdhocQueryRequest()
    {
        Federated = false;
        StartIndex = "0";
        MaxResults = "-1";
    }

    [XmlElement(Order = 0)]
    public ResponseOptionType ResponseOption;

    [XmlElement(Namespace = Constants.Xds.Namespaces.Rim, Order = 1)]
    public AdhocQueryType AdhocQuery;

    [XmlAttribute(AttributeName = "federated")]
    [DefaultValue(false)]
    public bool Federated;

    [XmlAttribute(AttributeName = "federation", DataType = "anyURI")]
    public string Federation;

    [XmlAttribute(AttributeName = "startIndex", DataType = "integer")]
    [DefaultValue("0")]
    public string StartIndex;

    [XmlAttribute(AttributeName = "maxResults", DataType = "integer")]
    [DefaultValue("-1")]
    public string MaxResults;
}
