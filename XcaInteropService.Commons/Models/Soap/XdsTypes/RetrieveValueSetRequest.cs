using System.Xml.Serialization;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(AnonymousType = true, Namespace = "urn:ihe:iti:svs:2008")]
[XmlRoot("RetrieveValueSetRequest", Namespace = "urn:ihe:iti:svs:2008", IsNullable = false)]
public class RetrieveValueSetRequest
{
    [XmlElement("ValueSet")]
    public ValueSetType ValueSet { get; set; }
}
