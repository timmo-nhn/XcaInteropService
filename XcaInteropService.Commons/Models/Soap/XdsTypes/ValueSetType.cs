using System.Xml.Schema;
using System.Xml.Serialization;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType("ValueSet", Namespace = "urn:ihe:iti:svs:2008")]
public class ValueSetType
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlAttribute(AttributeName = "lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string? lang;

    [XmlAttribute("displayName")]
    public string? DisplayName { get; set; }

    public ConceptListType ConceptList { get; set; }
}
