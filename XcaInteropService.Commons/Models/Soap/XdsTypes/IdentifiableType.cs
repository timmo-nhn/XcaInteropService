using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[XmlInclude(typeof(RegistryObjectType))]
[XmlInclude(typeof(NotificationType))]
[XmlInclude(typeof(AdhocQueryType))]
[XmlInclude(typeof(SubscriptionType))]
[XmlInclude(typeof(FederationType))]
[XmlInclude(typeof(RegistryType))]
[XmlInclude(typeof(PersonType))]
[XmlInclude(typeof(UserType))]
[XmlInclude(typeof(SpecificationLinkType))]
[XmlInclude(typeof(ServiceBindingType))]
[XmlInclude(typeof(ServiceType))]
[XmlInclude(typeof(RegistryPackageType))]
[XmlInclude(typeof(OrganizationType))]
[XmlInclude(typeof(ExtrinsicObjectType))]
[XmlInclude(typeof(ExternalLinkType))]
[XmlInclude(typeof(ClassificationSchemeType))]
[XmlInclude(typeof(ClassificationNodeType))]
[XmlInclude(typeof(AuditableEventType))]
[XmlInclude(typeof(AssociationType))]
[XmlInclude(typeof(ExternalIdentifierType))]
[XmlInclude(typeof(ClassificationType))]
[XmlInclude(typeof(ObjectRefType))]
[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public partial class IdentifiableType
{
    public IdentifiableType()
    {
        Id ??= Guid.NewGuid().ToString();
    }

    [XmlElement("Slot", Order = 0)]
    public SlotType[]? Slot;


    [XmlAttribute(AttributeName = "id", DataType = "anyURI")]
    public string? Id;


    [XmlAttribute(AttributeName = "home", DataType = "anyURI")]
    public string? Home;

    public void AddSlot(SlotType slotType)
    {
        if (Slot == null || Slot.Length == 0)
        {
            Slot = [slotType];
        }
        else
        {
            Slot = [.. Slot, slotType];
        }
    }

    public void AddSlot(string slotName, string[] valueList)
    {

        Slot ??= [];
        AddSlot(new()
        {
            Name = slotName,
            ValueList = new()
            {
                Value = valueList
            }
        });
    }

    public void UpdateSlot(string slotName, string[] valueList)
    {
        var slot = GetFirstSlot(slotName);
        if (slot == null)
        {
            AddSlot(slotName, valueList);
        }
        else
        { 
            var updatedValues = slot.ValueList?.Value?.ToList() ?? new List<string>();
            updatedValues.AddRange(valueList);
            slot.ValueList ??= new();
            slot.ValueList.Value = updatedValues.Distinct().ToArray();
        }
    }

    public SlotType[] GetSlots(string slotName)
    {
        if (Slot == null) return [new SlotType()];
        try
        {
            return Slot.Where(s => string.Equals(s.Name, slotName, StringComparison.CurrentCultureIgnoreCase)).ToArray();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public SlotType? GetFirstSlot(string slotName)
    {
        if (Slot == null) return new SlotType();
        return Slot.FirstOrDefault(s => string.Equals(s.Name, slotName, StringComparison.CurrentCultureIgnoreCase));
    }

    public SlotType? GetFirstSlot()
    {
        if (Slot?.Length == 0) return new SlotType();
        return Slot?.FirstOrDefault();
    }
}
