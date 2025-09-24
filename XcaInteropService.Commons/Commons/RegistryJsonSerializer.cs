using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using XcaInteropService.Commons.Models.Custom.RegistryDtos;

namespace XcaInteropService.Commons.Commons;

public static class RegistryJsonSerializer
{
    public static JsonSerializerOptions _jsonOptions = new()
    {
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase, 
        WriteIndented = true,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers =
            {
                type =>
                {
                    if (type.Type == typeof(RegistryObjectDto))
                    {
                        type.PolymorphismOptions = new JsonPolymorphismOptions
                        {
                            TypeDiscriminatorPropertyName = "$type",
                            IgnoreUnrecognizedTypeDiscriminators = true,
                            DerivedTypes =
                            {
                                new JsonDerivedType(typeof(DocumentEntryDto), "DocumentEntryDto"),
                                new JsonDerivedType(typeof(SubmissionSetDto), "SubmissionSetDto"),
                                new JsonDerivedType(typeof(AssociationDto), "AssociationDto")
                            }
                        };
                    }
                }
            }
        }
    };

    public static T? Deserialize<T>(string input)
    {
        return JsonSerializer.Deserialize<T>(input, _jsonOptions);
    }

    public static string Serialize(object input)
    {
        return JsonSerializer.Serialize(input, _jsonOptions);
    }
}
