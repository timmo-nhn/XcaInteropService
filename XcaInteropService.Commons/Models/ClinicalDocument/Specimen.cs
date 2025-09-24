using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("specimen", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Specimen
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("specimenRole")]
    public SpecimenRole SpecimenRole { get; set; }
}