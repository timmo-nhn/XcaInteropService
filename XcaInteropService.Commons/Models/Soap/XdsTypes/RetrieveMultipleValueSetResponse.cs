using System.Xml.Serialization;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(AnonymousType = true, Namespace = "urn:ihe:iti:svs:2008")]
[XmlRoot("RetrieveMultipleValueSetResponse", Namespace = "urn:ihe:iti:svs:2008", IsNullable = false)]
public class RetrieveMultipleValueSetResponse
{
    [XmlElement("ValueSet")]
    public DescribedValueSetType DescribedValueSet { get; set; }
}
