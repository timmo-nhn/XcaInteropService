using System.Xml;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ED : ANY
{
    [XmlAttribute("charset")]
    public string? Charset { get; set; }

    [XmlAttribute("compression")]
    public string? Compression { get; set; }

    [XmlAttribute("integrityCheck")]
    public byte[]? IntegrityCheck { get; set; }

    [XmlAttribute("integrityCheckAlgorithm")]
    public string? IntegrityCheckAlgorithm { get; set; }

    [XmlAttribute("language")]
    public string? Language { get; set; }

    [XmlAttribute("mediaType")]
    public string? MediaType { get; set; }

    [XmlAttribute("representation")]
    public string? Representation { get; set; }

    [XmlText]
    public string? Text { get; set; }

    [XmlAnyElement]
    public XmlElement[]? RawXmlElements { get; set; }

    [XmlIgnore]
    public string? Data
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(Text))
                return Text;

            if (RawXmlElements?.Length > 0)
            {
                var innerXmls = RawXmlElements.Select(x => x.OuterXml);
                return string.Join("", innerXmls);
            }

            return null;
        }
        set
        {
            Text = value;
            RawXmlElements = null;
        }
    }


    [XmlElement("reference")]
    public TEL? Reference { get; set; }

    [XmlElement("thumbnail")]
    public ED? Thumbnail { get; set; }

}
