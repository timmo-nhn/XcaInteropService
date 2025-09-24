using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace XcaInteropService.Commons.Models.Custom.RegistryDtos;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(DocumentEntryDto))]
[JsonDerivedType(typeof(SubmissionSetDto))]
[JsonDerivedType(typeof(AssociationDto))]
public class RegistryObjectDto
{
    public RegistryObjectDto()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
}