using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace XcaInteropService.WebService.Startup;

/// <summary>
/// Remove Examples from Swagger UI as recursive classes lock up the browser
/// </summary>
public class RemoveExamplesFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var soapSchemas = swaggerDoc.Components.Schemas
            .Where(s => s.Key.Contains("Soap"))
            .ToList();

        foreach (var soapSchema in soapSchemas)
        {
            soapSchema.Value.Properties.Clear();
        }
    }
}
