using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Commons.Models.Hl7.DataType;

/// <summary>
/// <strong>Extended Person Name (XPN)</strong><para/>
/// Similar to XCN but without identifier<para/>
/// Used in complex HL7-types, such as PID, where the identifier is contained in another property<para/>
/// <strong><a href="https://hl7-definition.caristix.com/v2/HL7v2.5/DataTypes/XPN">Extended Person Name (XPN) - hl7-definition.caristix.com</a></strong>
/// </summary>
public class XPN : Hl7Object
{
    [Hl7(Sequence = 1)]
    public string FamilyName { get; set; } = string.Empty;

    [Hl7(Sequence = 2)]
    public string GivenName { get; set; } = string.Empty;

    [Hl7(Sequence = 3)]
    public string FurtherGivenNames { get; set; } = string.Empty;

    [Hl7(Sequence = 4)]
    public string Suffix { get; set; } = string.Empty;

    [Hl7(Sequence = 5)]
    public string Prefix { get; set; } = string.Empty;

    [Hl7(Sequence = 6)]
    public string Degree { get; set; } = string.Empty;
}
