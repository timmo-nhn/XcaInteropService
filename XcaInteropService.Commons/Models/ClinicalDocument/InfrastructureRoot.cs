using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("infrastructureRoot", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class InfrastructureRoot : ANY
{
    [XmlElement("realmCode")]
    public List<CS>? RealmCode { get; set; }

    [XmlElement("typeId")]
    public II? TypeId { get; set; }

    [XmlElement("templateId")]
    public List<II> TemplateId { get; set; }
}

[Serializable]
[XmlType("responsibleParty", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ResponsibleParty : InfrastructureRoot
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("assignedEntity")]
    public AssignedEntity AssignedEntity { get; set; } = new();
}

[Serializable]
[XmlType("location", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Location : InfrastructureRoot
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("healthCareFacility")]
    public HealthcareFacility HealthcareFacility { get; set; } = new();

}

[Serializable]
[XmlType("referenceRange", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ReferenceRange : InfrastructureRoot
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("observationRange")]
    public ObservationRange ObservationRange { get; set; } = new();

}

[Serializable]
[XmlType("consumable", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Consumable : InfrastructureRoot
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("manufacturedProduct")]
    public ManufacturedProduct ManufacturedProduct { get; set; }
}

[Serializable]
[XmlType("product", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Product : InfrastructureRoot
{
    [XmlAttribute("typeCode")]
    public string? TypeCode { get; set; }

    [XmlElement("manufacturedProduct")]
    public ManufacturedProduct ManufacturedProduct { get; set; }
}
