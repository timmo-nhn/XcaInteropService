using System.Text;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.WebService.Services;

public class InitiatingGatewayService
{
    private readonly ILogger<InitiatingGatewayService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public InitiatingGatewayService(ILogger<InitiatingGatewayService> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<HttpResponseMessage> CrossGatewayQueryFromTargetCommunity(SoapEnvelope soapEnvelope, DomainConfig domainConfig)
    {
        var responseEnvelope = new SoapEnvelope();

        var newMessageId = Guid.NewGuid().ToString();

        _logger.LogInformation($"{soapEnvelope.Header.MessageId} - Start calling Responding gateway {domainConfig.QueryUrl}");

        _logger.LogInformation($"{soapEnvelope.Header.MessageId} - Assigning message id {newMessageId} for {domainConfig.DomainOid}");


        soapEnvelope.Header.MessageId = newMessageId;

        var sxmls = new SoapXmlSerializer();
        var soapXml = sxmls.SerializeSoapMessageToXmlString(soapEnvelope, Constants.XmlDefaultOptions.DefaultXmlWriterSettingsInline).Content;

        var content = new StringContent(soapXml, Encoding.UTF8, new System.Net.Http.Headers.MediaTypeHeaderValue(Constants.MimeTypes.SoapXml));

        var client = _httpClientFactory.CreateClient();
        var response = await client.PostAsync(domainConfig.QueryUrl, content);

        return response;
    }
}