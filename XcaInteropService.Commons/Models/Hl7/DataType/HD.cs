using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Commons.Models.Hl7.DataType;

/// <summary>
/// <strong>Hierarchic Designator (HD)</strong><para/>
/// Identifies the source or assigning authority of an item (like a patient ID or a message), supporting uniqueness across systems. Usually an OID<para/>
/// <strong><a href="https://hl7-definition.caristix.com/v2/HL7v2.5/DataTypes/HD">Hierarchic Designator (HD) - hl7-definition.caristix</a></strong>
/// </summary>
public class HD : Hl7Object
{
    [Hl7(Sequence = 1)]
    public string NamespaceId { get; set; }
    [Hl7(Sequence = 2)]
    public string UniversalId { get; set; }
    [Hl7(Sequence = 3)]
    public string UniversalIdType { get; set; }
}
