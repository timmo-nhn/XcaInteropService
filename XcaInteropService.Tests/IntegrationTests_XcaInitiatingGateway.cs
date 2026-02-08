using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Tests.Helpers;
using XcaInteropService.WebService;

namespace XcaInteropService.Tests;

public class IntegrationTests_XcaInitiatingGateway : IntegrationTests_DefaultFixture
{
    public IntegrationTests_XcaInitiatingGateway(WebApplicationFactory<Program> factory) : base(factory) { }

    [Fact]
    public async Task InitiatingGateway_CrossGatewayQuery()
    {
        var testDataPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "TestData");
        var testDataFiles = Directory.GetFiles(testDataPath);

        var integrationTestFiles = Directory.GetFiles(Path.Combine(testDataPath, "IntegrationTests"));

        var crossGatewayQuery = TestHelpers.LoadNewXmlDocument(File.ReadAllText(integrationTestFiles.FirstOrDefault(f => f.Contains("IT_iti-38.xml"))));

        var httpResponse = await _client.PostAsync("/XCA/services/InitiatingGatewayService",
            new StringContent(crossGatewayQuery.OuterXml, Encoding.UTF8, Constants.MimeTypes.SoapXml));

        var body = await httpResponse.Content.ReadAsStringAsync();
    }
}
