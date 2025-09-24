using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("identifiedBy", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class IdentifiedBy
{
    [XmlAttribute("typeCode")]
    public string TypeCode { get; set; }

    [XmlElement("alternateIdentification", Namespace = Constants.Hl7.Namespaces.Hl7Sdtc)]
    public AlternateIdentification SdtcAlternateIdentification { get; set; }
}