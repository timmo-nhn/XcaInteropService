using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Commons.Models.Hl7.DataType;

/// <summary>
/// <strong>Extended Composite Name and Identification Number for Organizations (XON)</strong><para/>
/// Used to uniquely identify an organization <para/>
/// <strong><a href="https://hl7-definition.caristix.com/v2/HL7v2.5/DataTypes/XON">Extended Composite Name and Identification Number for Organizations (XON) - hl7-definition.caristix.com</a></strong>
/// </summary>
public class XON : Hl7Object
{
    [Hl7(Sequence = 1)]
    public string OrganizationName { get; set; }
    [Hl7(Sequence = 2)]
    public string OrganizationNameTypeCode { get; set; } //Type CWE - Not implemented
    [Hl7(Sequence = 3)]
    public string IdNumber { get; set; }
    [Hl7(Sequence = 4)]
    public string IdentifierCheckDigit { get; set; }
    [Hl7(Sequence = 5)]
    public string CheckDigitScheme { get; set; }
    [Hl7(Sequence = 6)]
    public HD AssigningAuthority { get; set; }
    [Hl7(Sequence = 7)]
    public string IdentifierTypeCode { get; set; }
    [Hl7(Sequence = 8)]
    public HD AssigningFacility { get; set; }
    [Hl7(Sequence = 9)]
    public string NameRepresentationCode { get; set; }
    [Hl7(Sequence = 10)]
    public string OrganizationIdentifier { get; set; }
}
