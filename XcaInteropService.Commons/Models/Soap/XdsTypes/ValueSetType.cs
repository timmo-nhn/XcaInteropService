using System.Text.Json.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType("ValueSet", Namespace = "urn:ihe:iti:svs:2008")]
public class ValueSetType
{
    [XmlAttribute("id")]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("lang")]
    [XmlAttribute(AttributeName = "lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string? Language;

    [JsonPropertyName("displayName")]
    [XmlAttribute("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("conceptList")]
    public ConceptListType ConceptList { get; set; }
}
