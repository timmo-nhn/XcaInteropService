using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Text;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Extensions;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Serializers;

public class SoapEnvelopeModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(SoapEnvelope))
        {
            return new BinderTypeModelBinder(typeof(SoapEnvelopeModelBinder));
        }

        return null;
    }
}

public class SoapEnvelopeModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }
        var sxmls = new SoapXmlSerializer();

        var request = bindingContext.HttpContext.Request;
        var response = bindingContext.HttpContext.Response;


        if (request.ContentType != null && !(request.ContentType.Contains(Constants.MimeTypes.SoapXml) || request.ContentType.Contains(Constants.MimeTypes.XopXml) || request.ContentType.Contains(Constants.MimeTypes.MultipartRelated)))
        {
            await CreateStatus500SoapError("InvalidContentType", "The request content type is not XML.", response);
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        var xmlContent = request.Body;

        if (xmlContent is null)
        {
            await CreateStatus500SoapError("EmptyRequestBody", "The request body is empty", response);
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        try
        {
            request.EnableBuffering();
            var xmlString = string.Empty;

            if (request.ContentType != null && (request.ContentType.Contains(Constants.MimeTypes.XopXml) || request.ContentType.Contains(Constants.MimeTypes.MultipartRelated)))
            {
                xmlString = await HttpRequestResponseExtensions.ReadMultipartContentFromRequest(bindingContext.HttpContext);
            }
            else
            {
                using (var sr = new StreamReader(xmlContent))
                {
                    xmlString = await sr.ReadToEndAsync();
                }
            }


            var soapEnvelope = sxmls.DeserializeSoapMessage<SoapEnvelope>(xmlString);

            bindingContext.Result = ModelBindingResult.Success(soapEnvelope);
        }
        catch (Exception ex)
        {
            await CreateStatus500SoapError(ex.Message, "Serialization error", response);
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }
    }

    public async Task CreateStatus500SoapError(string message, string code, HttpResponse response)
    {
        var sxmls = new SoapXmlSerializer();
        var soapFault = SoapExtensions.CreateSoapFault(message, code).Value;
        var soapFaultXml = sxmls.SerializeSoapMessageToXmlString(soapFault).Content;

        response.StatusCode = StatusCodes.Status500InternalServerError;
        response.ContentType = "application/soap+xml";
        response.ContentLength = Encoding.UTF8.GetByteCount(soapFaultXml);

        await response.Body.WriteAsync(Encoding.UTF8.GetBytes(soapFaultXml));
    }

}
