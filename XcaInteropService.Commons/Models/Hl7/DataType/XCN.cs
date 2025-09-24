using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Commons.Models.Hl7.DataType;

/// <summary>
/// <strong>Extended Composite ID Number and Name for Persons (XCN)</strong><para/>
/// Used to uniquely identify a person (identifier and full name)<para/>
/// <strong><a href="https://hl7-definition.caristix.com/v2/HL7v2.5/DataTypes/XCN">Extended Composite ID Number and Name for Persons (XCN) - hl7-definition.caristix.com</a></strong>
/// </summary>
public class XCN : Hl7Object
{
    [Hl7(Sequence = 1)]
    public string PersonIdentifier { get; set; }
    [Hl7(Sequence = 2)]
    public string FamilyName { get; set; }
    [Hl7(Sequence = 3)]
    public string GivenName { get; set; }
    [Hl7(Sequence = 4)]
    public string MiddleName { get; set; } // Second and Further Given Names or Initials Thereof
    [Hl7(Sequence = 5)]
    public string Suffix { get; set; }
    [Hl7(Sequence = 6)]
    public string Prefix { get; set; }
    [Hl7(Sequence = 7)]
    public string Degree { get; set; }
    [Hl7(Sequence = 8)]
    public string SourceTable { get; set; } //Type CWE - Not implemented
    [Hl7(Sequence = 9)]
    public HD AssigningAuthority { get; set; }
}
