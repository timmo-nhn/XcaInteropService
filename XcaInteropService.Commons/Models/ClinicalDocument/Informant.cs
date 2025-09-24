using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlType("informant", Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class Informant : InfrastructureRoot
{
    [XmlAttribute("typeCode")]
    public string? typecode { get; set; }

    [XmlAttribute("contextControlCode")]
    public string? ContextControlCode { get; set; }


    internal AssignedEntity? _assignedEntity;
    internal RelatedEntity? _relatedEntity;


    [XmlElement("assignedEntity")]
    public AssignedEntity? AssignedEntity
    {
        get => _assignedEntity;
        set
        {
            if (_relatedEntity != null)
                _assignedEntity = null;
            else
                _assignedEntity = value;
        }
    }

    [XmlElement("relatedEntity")]
    public RelatedEntity? RelatedEntity
    {
        get => _relatedEntity;
        set
        {
            if (_assignedEntity != null)
                _relatedEntity = null;
            else
                _relatedEntity = value;
        }
    }

    public bool ShouldSerializeAssignedEntity() => _assignedEntity != null;
    public bool ShouldSerializeRelatedEntity() => _relatedEntity != null;

}


