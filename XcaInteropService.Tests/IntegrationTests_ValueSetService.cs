using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Serializers;
using XcaInteropService.Tests.Helpers;
using XcaInteropService.WebService;
using XcaInteropService.WebService.Services;

namespace XcaInteropService.Tests;


public class IntegrationTests_ValueSetService : IntegrationTests_DefaultFixture
{
    public IntegrationTests_ValueSetService(WebApplicationFactory<Program> factory) : base(factory) { }
    
    [Fact]
    public async Task RetrieveValueSet()
    {
        var testDataPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "TestData");
        var testDataFiles = Directory.GetFiles(testDataPath);
        var integrationTestFiles = Directory.GetFiles(Path.Combine(testDataPath, "IntegrationTests"));

        var valueSets = _valueSetRepositoryService.GetValueSetList();

        if (valueSets == null || valueSets.Count == 0)
        {
            _valueSetRepositoryService.UploadSingleConcept("1.2.3.4", "en", "123456-22", "2.16.578.1.12.4.1.4.1.2.3", "Test 123 æøåÆØÅ");
        }

        valueSets = _valueSetRepositoryService.GetValueSetList();

        var sxmls = new SoapXmlSerializer();

        var randomValueSet = valueSets.ElementAt(Random.Shared.Next(valueSets.Count));

        var valueSetRequestEnvelope = sxmls.DeserializeXmlString<SoapEnvelope>(File.ReadAllText(integrationTestFiles.FirstOrDefault(f => f.Contains("IT_iti-48.xml"))));

        valueSetRequestEnvelope.Body.RetrieveValueSetRequest.ValueSet.Id = randomValueSet.Id;
        valueSetRequestEnvelope.Body.RetrieveValueSetRequest.ValueSet.Language = randomValueSet.Language;

        var retrieveValueSetQuery = sxmls.SerializeToXmlString(valueSetRequestEnvelope).Content;

        var httpResponse = await _client.PostAsync("/ValueSetRepository/services/ValueSetRepositoryService", new StringContent(retrieveValueSetQuery, Encoding.UTF8, Constants.MimeTypes.SoapXml));

        var body = await httpResponse.Content.ReadAsStringAsync();
        Assert.NotEmpty(body);

        var soapEnvelope = sxmls.DeserializeXmlString<SoapEnvelope>(body);
        Assert.NotEmpty(soapEnvelope.Body?.RetrieveValueSetResponse?.ValueSet?.ConceptList?.Concept ?? []);
    }

    [Fact]
    public async Task RetrieveMultipleValueSets()
    {
        var testDataPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "TestData");
        var testDataFiles = Directory.GetFiles(testDataPath);

        var integrationTestFiles = Directory.GetFiles(Path.Combine(testDataPath, "IntegrationTests"));

        var retrieveValueSetQuery = TestHelpers.LoadNewXmlDocument(File.ReadAllText(integrationTestFiles.FirstOrDefault(f => f.Contains("IT_iti-60.xml"))));

        var httpResponse = await _client.PostAsync("/ValueSetRepository/services/ValueSetRepositoryService",
            new StringContent(retrieveValueSetQuery.OuterXml, Encoding.UTF8, Constants.MimeTypes.SoapXml));

        var body = await httpResponse.Content.ReadAsStringAsync();

    }
}