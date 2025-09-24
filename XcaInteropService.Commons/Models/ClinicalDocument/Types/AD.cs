using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class AD : ANY
{
    [XmlAttribute("nullFlavor")]
    public string? NullFlavor { get; set; }

    [XmlAttribute("use")]
    public List<string>? Use { get; set; }

    [XmlElement("delimiter")]
    public List<ADXP>? Delimiter { get; set; }

    [XmlElement("country")]
    public List<ADXP>? Country { get; set; }

    [XmlElement("state")]
    public List<ADXP>? State { get; set; }

    [XmlElement("county")]
    public List<ADXP>? County { get; set; }

    [XmlElement("city")]
    public List<ADXP>? City { get; set; }

    [XmlElement("postalCode")]
    public List<ADXP>? PostalCode { get; set; }

    [XmlElement("streetAddressLine")]
    public List<ADXP>? StreetAddressLine { get; set; }

    [XmlElement("houseNumber")]
    public List<ADXP>? HouseNumber { get; set; }

    [XmlElement("houseNumberNumeric")]
    public List<ADXP>? HouseNumberNumeric { get; set; }

    [XmlElement("direction")]
    public List<ADXP>? Direction { get; set; }

    [XmlElement("streetName")]
    public List<ADXP>? StreetName { get; set; }

    [XmlElement("streetNameBase")]
    public List<ADXP>? StreetNameBase { get; set; }

    [XmlElement("streetNameType")]
    public List<ADXP>? StreetNameType { get; set; }

    [XmlElement("additionalLocator")]
    public List<ADXP>? AdditionalLocator { get; set; }

    [XmlElement("unitID")]
    public List<ADXP>? UnitId { get; set; }

    [XmlElement("unitType")]
    public List<ADXP>? UnitType { get; set; }

    [XmlElement("careOf")]
    public List<ADXP>? CareOf { get; set; }

    [XmlElement("censusTract")]
    public List<ADXP>? CensusTract { get; set; }

    [XmlElement("deliveryAddressLine")]
    public List<ADXP>? DeliveryAddressLine { get; set; }

    [XmlElement("deliveryInstallationType")]
    public List<ADXP>? DeliveryInstallationType { get; set; }

    [XmlElement("deliveryInstallationArea")]
    public List<ADXP>? DeliveryInstallationArea { get; set; }

    [XmlElement("deliveryInstallationQualifier")]
    public List<ADXP>? DeliveryInstallationQualifier { get; set; }

    [XmlElement("deliveryMode")]
    public List<ADXP>? DeliveryMode { get; set; }

    [XmlElement("deliveryModeIdentifier")]
    public List<ADXP>? DeliveryModeIdentifier { get; set; }

    [XmlElement("buildingNumberSuffix")]
    public List<ADXP>? BuildingNumberSuffix { get; set; }

    [XmlElement("postBox")]
    public List<ADXP>? PostBox { get; set; }

    [XmlElement("precinct")]
    public List<ADXP>? Precinct { get; set; }
}
