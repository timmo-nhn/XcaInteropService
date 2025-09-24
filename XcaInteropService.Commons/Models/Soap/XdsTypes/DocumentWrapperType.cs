using System.Xml.Serialization;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

public class DocumentWrapper
{
    [XmlElement("Include", typeof(IncludeType), Namespace = "http://www.w3.org/2004/08/xop/include")]
    [XmlText(typeof(string))]
    [XmlChoiceIdentifier("ContentType")]
    public object? Content { get; set; }

    [XmlIgnore]
    public DocumentItemType ContentType { get; set; } = DocumentItemType.Include;
}

public enum DocumentItemType
{
    Include,
    Base64
}
