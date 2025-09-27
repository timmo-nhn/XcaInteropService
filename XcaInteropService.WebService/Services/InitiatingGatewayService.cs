using System.Net.Http.Headers;
using System.Text;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Extensions;
using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Models.Soap.XdsTypes;
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

    public async Task<SoapEnvelope> ProcessCrossGatewayQueryResponseMessages(HttpResponseMessage[] httpRequests, string sessionId, DomainConfigMap domainConfigMap)
    {
        var responseEnvelope = new SoapEnvelope();

        responseEnvelope.Header ??= new();
        responseEnvelope.Header.Action = Constants.Xds.OperationContract.Iti38Reply;
        responseEnvelope.Body ??= new();

        var sxmls = new SoapXmlSerializer();

        foreach (var response in httpRequests)
        {
            var domain = domainConfigMap.Domains.FirstOrDefault(dom => dom.QueryUrl == response.RequestMessage?.RequestUri?.AbsoluteUri);

            if (domain == null)
            {
                _logger.LogInformation($"{sessionId} - Domain for {response.RequestMessage?.RequestUri?.AbsoluteUri} not found, that should'nt happen?!");
                continue;
            }

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"{sessionId} - Response retrieved from {response.RequestMessage?.RequestUri}\nLocation: {domain.DomainOid}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var communitySoapEnvelope = sxmls.DeserializeSoapMessage<SoapEnvelope>(responseBody);

                var registryObjects = communitySoapEnvelope.Body.AdhocQueryResponse?.RegistryObjectList;
                var registryErrors = communitySoapEnvelope.Body.AdhocQueryResponse?.RegistryErrorList?.RegistryError;

                _logger.LogInformation($"{sessionId} - Retrieved {registryObjects?.Length ?? 0} Registry objects\nLocation: {domain.DomainOid}");

                responseEnvelope.Body.AdhocQueryResponse ??= new();
                responseEnvelope.Body.AdhocQueryResponse.RegistryErrorList ??= new();

                if (registryObjects != null && registryObjects.Length != 0)
                {
                    responseEnvelope.Body.AdhocQueryResponse.RegistryObjectList = [.. registryObjects];
                }

                if (registryErrors != null && registryErrors?.Length != 0)
                {
                    responseEnvelope.Body.AdhocQueryResponse.RegistryErrorList.RegistryError = [.. registryErrors];
                }
            }
            else
            {
                _logger.LogWarning($"{sessionId} - Gateway {response.RequestMessage?.RequestUri} failed with HTTP status {response.StatusCode}");
                _logger.LogWarning($"{sessionId} - {await response.Content.ReadAsStringAsync()}");

                responseEnvelope.Body.RegistryResponse ??= new();
                responseEnvelope.Body.RegistryResponse.AddError(XdsErrorCodes.XDSUnavailableCommunity, $"Could not retrieve from target domain {domain.DomainOid}", domain.DomainOid);
            }
        }

        if (responseEnvelope.Body.RegistryResponse?.RegistryErrorList?.RegistryError != null && responseEnvelope.Body.RegistryResponse?.RegistryErrorList?.RegistryError.Length != 0)
        {
            responseEnvelope.Body.RegistryResponse ??= new();
            responseEnvelope.Body.RegistryResponse.RegistryErrorList ??= new();
            responseEnvelope.Body.RegistryResponse.RegistryErrorList.HighestSeverity = SoapExtensions.GetHighestSeverityErrorFromSoapEnvelope(responseEnvelope);
        }


        // Log potential errors
        for (int i = 0; i < (responseEnvelope?.Body?.RegistryResponse?.RegistryErrorList?.RegistryError ?? []).Length; i++)
        {
            var error = responseEnvelope?.Body.RegistryResponse?.RegistryErrorList?.RegistryError[i];
            if (error == null) continue;

            _logger.LogWarning($"{sessionId}\n#############  Error #{i + 1}  #############\n\tCode: {error.ErrorCode}\n\tCodeContext: {error.CodeContext}\n\tLocation: {error.Location}\n######################################");
        }

        return responseEnvelope;
    }

    public async Task<SoapEnvelope> CrossGatewayRetrieveFromTargetCommunity(SoapEnvelope soapEnvelope, string sessionId, DomainConfigMap domainConfigMap)
    {
        var sxmls = new SoapXmlSerializer();

        var responseEnvelope = new SoapEnvelope();
        responseEnvelope.Header ??= new();
        responseEnvelope.Body ??= new();

        var documentRequests = soapEnvelope.Body.RetrieveDocumentSetRequest?.DocumentRequest;

        foreach (var documentRequest in documentRequests ?? [])
        {
            var domain = domainConfigMap.Domains.FirstOrDefault(dom => dom.DomainOid == documentRequest.HomeCommunityId);

            if (domain == null)
            {
                responseEnvelope.Body.RegistryResponse ??= new();
                responseEnvelope.Body.RegistryResponse.AddError(XdsErrorCodes.XDSUnknownCommunity, $"Unknown HomeCommunityId {documentRequest.HomeCommunityId}", documentRequest.HomeCommunityId);
                continue;
            }

            var soapEnvelopeForSingleDocumentRequest = soapEnvelope.DeepCopy();
            if (soapEnvelopeForSingleDocumentRequest == null)
            {
                _logger.LogWarning($"{sessionId} - Duplicating Soap envelope failed!");
                continue;
            }

            // Even if the request has multiple documents, fetch them one at a time
            // Probably not effective, but fetching multiple documents really isnt a thing in XDS in Norway
            soapEnvelopeForSingleDocumentRequest.Body.RetrieveDocumentSetRequest ??= new();
            soapEnvelopeForSingleDocumentRequest.Body.RetrieveDocumentSetRequest.DocumentRequest = [documentRequest];

            var multipartRequestContent = HttpRequestResponseExtensions.ConvertToMultipartMessage(soapEnvelopeForSingleDocumentRequest, out var boundary);

            string contentId = null;

            if (multipartRequestContent.FirstOrDefault()?.Headers.TryGetValues("Content-ID", out var contentIdValues) ?? false)
            {
                contentId = contentIdValues.First();
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, domain.RetrieveUrl)
            {
                Content = multipartRequestContent
            };

            requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse($"multipart/related; type=\"{Constants.MimeTypes.XopXml}\"; boundary=\"{boundary}\"; start=\"{contentId}\"; start-info=\"{Constants.MimeTypes.SoapXml}\"");


            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning($"{sessionId} - Gateway {response.RequestMessage?.RequestUri} failed with HTTP status {response.StatusCode}");

                responseEnvelope.Body.RegistryResponse ??= new();
                responseEnvelope.Body.RegistryResponse.AddError(XdsErrorCodes.XDSUnavailableCommunity, $"Could not retrieve from target domain {domain.DomainOid}", domain.DomainOid);
                continue;
            }

            var content = await response.Content.ReadAsStringAsync();

            var responseBody = await HttpRequestResponseExtensions.ReadFirstMultiPartFromRequest(response);
            var documentContent = await HttpRequestResponseExtensions.ReadLastMultipartFromRequest(response);

            var requestResponseSoapEnvelope = sxmls.DeserializeSoapMessage<SoapEnvelope>(responseBody);
            var requestRegistryResponse = requestResponseSoapEnvelope.Body.RegistryResponse;

            var documentResponse = requestResponseSoapEnvelope.Body.RetrieveDocumentSetResponse?.DocumentResponse.FirstOrDefault();

            if (documentResponse != null)
            {
                var document = new DocumentResponseType()
                {
                    DocumentUniqueId = documentResponse.DocumentUniqueId,
                    RepositoryUniqueId = documentResponse.RepositoryUniqueId,
                    HomeCommunityId = documentResponse.HomeCommunityId,
                    MimeType = documentResponse.MimeType
                };
                document.SetInlineDocument(Encoding.UTF8.GetBytes(documentContent));

                responseEnvelope.Header.Action = soapEnvelope.GetCorrespondingRequestAction();
                responseEnvelope.Body.RetrieveDocumentSetResponse ??= new();
                responseEnvelope.Body.RetrieveDocumentSetResponse.DocumentResponse ??= [];
                responseEnvelope.Body.RetrieveDocumentSetResponse.DocumentResponse = [.. responseEnvelope.Body.RetrieveDocumentSetResponse.DocumentResponse, document];
            }
            else
            {
                var registryErrors = requestRegistryResponse?.RegistryErrorList?.RegistryError;
                if (registryErrors != null && registryErrors.Length != 0)
                {
                    responseEnvelope.Body.RegistryResponse ??= new();
                    responseEnvelope.Body.RegistryResponse.RegistryErrorList ??= new();
                    responseEnvelope.Body.RegistryResponse.RegistryErrorList.RegistryError = [.. responseEnvelope.Body.RegistryResponse.RegistryErrorList.RegistryError, .. registryErrors];
                }
            }
        }

        if (responseEnvelope.Body.RegistryResponse?.RegistryErrorList?.RegistryError != null && responseEnvelope.Body.RegistryResponse?.RegistryErrorList?.RegistryError.Length != 0)
        {
            responseEnvelope.Body.RegistryResponse ??= new();
            responseEnvelope.Body.RegistryResponse.RegistryErrorList ??= new();
            responseEnvelope.Body.RegistryResponse.RegistryErrorList.HighestSeverity = SoapExtensions.GetHighestSeverityErrorFromSoapEnvelope(responseEnvelope);
        }

        // Log potential errors
        for (int i = 0; i < (responseEnvelope?.Body.RegistryResponse?.RegistryErrorList?.RegistryError ?? []).Length; i++)
        {
            var error = responseEnvelope?.Body.RegistryResponse?.RegistryErrorList?.RegistryError[i];
            if (error == null) continue;

            _logger.LogWarning($"{sessionId}\n#############  Error #{i + 1}  #############\n\tCode: {error.ErrorCode}\n\tCodeContext: {error.CodeContext}\n\tLocation: {error.Location}\n######################################");
        }


        return responseEnvelope;
    }
}