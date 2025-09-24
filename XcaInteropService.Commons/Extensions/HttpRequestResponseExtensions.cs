using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System.Buffers.Text;
using System.Text;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Commons.Extensions;

public static class HttpRequestResponseExtensions
{
    public static async Task<string> GetHttpRequestBodyAsStringAsync(this HttpRequest httpRequest)
    {
        using var reader = new StreamReader(httpRequest.Body, leaveOpen: true);
        var bodyContent = await reader.ReadToEndAsync();
        httpRequest.Body.Position = 0; // Reset stream position for next reader
        return bodyContent;
    }

    public static async Task<string> ReadMultipartContentFromRequest(HttpContext httpContext)
    {
        var sb = new StringBuilder();

        if (!MediaTypeHeaderValue.TryParse(httpContext.Request.ContentType, out MediaTypeHeaderValue? mediaTypeHeaderValue)
        || !mediaTypeHeaderValue.MediaType.Equals("multipart/form-data", StringComparison.OrdinalIgnoreCase))
        {
            var boundary = GetBoundary(mediaTypeHeaderValue, 512);

            var multipartReader = new MultipartReader(boundary, httpContext.Request.Body);
            while (await multipartReader.ReadNextSectionAsync() is { } section)
            {
                using (var sr = new StreamReader(section.Body))
                {
                    sb.Append(await sr.ReadToEndAsync());
                }
            }
        }

        httpContext.Request.Body.Position = 0;
        return sb.ToString();
    }

    public static string GetBoundary(MediaTypeHeaderValue contentType, int lengthLimit)
    {
        var boundary = HeaderUtilities.RemoveQuotes(contentType.Boundary);
        if (StringSegment.IsNullOrEmpty(boundary))
        {
            throw new InvalidDataException("Missing content-type boundary.");
        }
        if (boundary.Length > lengthLimit)
        {
            throw new InvalidDataException($"Multipart boundary length limit {lengthLimit} exceeded.");
        }
        return boundary.ToString();
    }


    public static MultipartContent ConvertToMultipartResponse(SoapEnvelope soapEnvelope, out string boundary)
    {
        var documentResponses = soapEnvelope.Body.RetrieveDocumentSetResponse?.DocumentResponse;
        var sxmls = new SoapXmlSerializer(Constants.XmlDefaultOptions.DefaultXmlWriterSettingsInline);

        var documentContents = new List<HttpContent>();

        if (documentResponses != null)
        {
            foreach (var documentResponse in documentResponses)
            {
                if (string.IsNullOrWhiteSpace(documentResponse.Document?.InnerText)) continue;

                var documentBytes = new byte[0];

                if (Base64.IsValid(documentResponse.Document.InnerText) && documentResponse.MimeType == Constants.MimeTypes.Hl7v3Xml)
                {
                    var documentContent = Convert.FromBase64String(documentResponse.Document.InnerText);
                    documentBytes = new byte[documentContent.Length];
                    documentBytes = documentContent;
                }
                else
                {
                    var documentContent = Encoding.UTF8.GetBytes(documentResponse.Document.InnerText);
                    documentBytes = new byte[documentContent.Length];
                    documentBytes = documentContent;
                }


                var documentByteArrayContent = new ByteArrayContent(documentBytes);

                var contentId = $"{Guid.NewGuid().ToString().Replace("-", "")}@xcadocumentsource.com";

                documentByteArrayContent.Headers.ContentType = new(documentResponse.MimeType);

                documentByteArrayContent.Headers.Add("Content-ID", [$"<{contentId}>"]);
                documentByteArrayContent.Headers.Add("Content-Transfer-Encoding", "binary");

                documentContents.Add(documentByteArrayContent);

                // The corresponding <Include>-part in the DocumentResponse
                documentResponse.SetXopInclude($"cid:{contentId}");
            }
        }

        var soapString = sxmls.SerializeSoapMessageToXmlString(soapEnvelope);
        var soapContent = new StringContent(soapString.Content, Encoding.UTF8, Constants.MimeTypes.XopXml);
        soapContent.Headers.Add("Content-ID", [$"<{Guid.NewGuid().ToString().Replace("-", "")}@xcadocumentsource.com>"]);
        soapContent.Headers.ContentType?.Parameters.Add(new System.Net.Http.Headers.NameValueHeaderValue("type", $"\"{Constants.MimeTypes.SoapXml}\""));
        soapContent.Headers.Add("Content-Transfer-Encoding", "binary");

        boundary = $"MIMEBoundary_{Guid.NewGuid().ToString().Replace("-", "")}";

        var multipart = new MultipartContent("related", boundary);

        multipart.Add(soapContent);

        foreach (var docContent in documentContents)
            multipart.Add(docContent);

        multipart.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(Constants.MimeTypes.MultipartRelated, Encoding.UTF8.BodyName);

        return multipart;
    }

    public static void SendAsyncResponse(string replyTo, SoapEnvelope responseEnvelope)
    {
    }
}
