using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Commons.Models.Hl7.DataType;

/// <summary>
/// <strong>Extended Composite ID with Check Digit (CX)</strong><para/>
/// CX represents an identifier, such as a patient nin/fnr, including optional metadata like the assigning authority and identifier type. <para/>
/// <strong><a href="https://hl7-definition.caristix.com/v2/HL7v2.5/DataTypes/CX">Extended Composite ID with Check Digit (CX) - hl7-definition.caristix.com</a></strong>
/// </summary>
public class CX : Hl7Object
{
    [Hl7(Sequence = 1)]
    public string IdNumber { get; set; }

    [Hl7(Sequence = 2)]
    public string IdentifierCheckDigit { get; set; }

    [Hl7(Sequence = 3)]
    public string CheckDigitScheme { get; set; }

    [Hl7(Sequence = 4)]
    public HD AssigningAuthority { get; set; }

    [Hl7(Sequence = 5)]
    public string IdentifierTypeCode { get; set; }

    [Hl7(Sequence = 6)]
    public HD AssigningFacility { get; set; }
}
