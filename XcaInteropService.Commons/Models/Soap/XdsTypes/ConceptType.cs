using System.Text.Json.Serialization;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Svs)]
public class ConceptType
{
    [JsonPropertyName("code")]
    [XmlAttribute(AttributeName = "code")]
    public string Code { get; set; }

    [JsonPropertyName("codeSystem")]
    [XmlAttribute(AttributeName = "codeSystemName")]
    public string CodeSystemName { get; set; }

    [JsonPropertyName("displayName")]
    [XmlAttribute(AttributeName = "displayName")]
    public string DisplayName { get; set; }
}