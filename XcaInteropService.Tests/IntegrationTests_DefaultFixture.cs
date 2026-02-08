using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Serializers;
using XcaInteropService.Tests.Helpers;
using XcaInteropService.WebService.Services;

namespace XcaInteropService.Tests;


public class IntegrationTests_DefaultFixture : IClassFixture<WebApplicationFactory<WebService.Program>>
{
    internal readonly HttpClient _client;

    internal readonly ValueSetRepositoryService _valueSetRepositoryService;

    public IntegrationTests_DefaultFixture(WebApplicationFactory<WebService.Program> factory)
    {
        _client = factory.CreateClient();
        using var scope = factory.Services.CreateScope();
        _valueSetRepositoryService = scope.ServiceProvider.GetRequiredService<ValueSetRepositoryService>();
    }
}