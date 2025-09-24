using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Extensions;

public static class SoapExtensions
{
    public static object? CreateAsyncAcceptedMessage(SoapEnvelope soapEnvelope)
    {
        throw new NotImplementedException();
    }

    public static SoapRequestResult<SoapEnvelope> CreateSoapFault(string faultCode, string? subCode = null, string? detail = null, string? faultReason = null)
    {
        var resultEnvelope = new SoapRequestResult<SoapEnvelope>()
        {
            Value = new SoapEnvelope()
            {
                Header = new()
                {
                    Action = Constants.Soap.Namespaces.AddressingSoapFault,
                },
                Body = new()
                {
                    Fault = new()
                    {
                        Code = new()
                        {
                            Value = faultCode,
                            Subcode = string.IsNullOrWhiteSpace(subCode) ? null : new() { Value = subCode ?? string.Empty }
                        },
                        Reason = new()
                        {
                            Text = string.IsNullOrEmpty(faultReason) ? "soapenv:Reciever" : faultReason
                        },
                        Detail = string.IsNullOrWhiteSpace(detail) ? null : new Detail() { Value = new() { Action = detail } }
                    }
                }
            }
        };

        return resultEnvelope;
    }

    public static SoapRequestResult<SoapEnvelope> CreateSoapResultRegistryResponse(RegistryResponseType message)
    {
        var resultEnvelope = new SoapRequestResult<SoapEnvelope>()
        {
            Value = new SoapEnvelope()
            {
                Header = new(),
                Body = new()
                {
                    RegistryResponse = message
                }
            }
        };
        if (resultEnvelope.Value.Body.RegistryResponse is not null)
        {
            // Base Success property on whether Value...RegistryErrorList has any errors
            if (resultEnvelope.Value.Body.RegistryResponse.RegistryErrorList is null)
            {
                resultEnvelope.IsSuccess = true;
            }
            else
            {
                var isSuccess = bool.Equals(false, resultEnvelope.Value.Body.RegistryResponse.RegistryErrorList.RegistryError
                .Any(re => re.Severity == Constants.Xds.ErrorSeverity.Error));
                resultEnvelope.Value.Header.Action = isSuccess is true ? Constants.Soap.Namespaces.Addressing : Constants.Soap.Namespaces.AddressingSoapFault;
                resultEnvelope.IsSuccess = isSuccess;
            }
        }

        return resultEnvelope;
    }

    public static SoapRequestResult<SoapEnvelope> CreateSoapResultResponse(SoapEnvelope message)
    {
        var resultEnvelope = new SoapRequestResult<SoapEnvelope>()
        {
            Value = new SoapEnvelope()
            {
                Header = message.Header,
                Body = message.Body
            }
        };
        resultEnvelope.Value.Header.Action = message.Header.Action;
        resultEnvelope.Value.Header.RelatesTo = message.Header.MessageId;


        if (resultEnvelope.Value.Body.RegistryResponse is not null)
        {
            // Base Success property on whether Value...RegistryErrorList has any errors
            if (resultEnvelope.Value.Body.RegistryResponse.RegistryErrorList is null)
            {
                resultEnvelope.IsSuccess = true;
            }
            else
            {
                var isSuccess = bool.Equals(false, resultEnvelope.Value.Body.RegistryResponse.RegistryErrorList.RegistryError
                .Any(re => re.Severity == Constants.Xds.ErrorSeverity.Error));
                resultEnvelope.Value.Header.Action = isSuccess is true ? Constants.Soap.Namespaces.Addressing : Constants.Soap.Namespaces.AddressingSoapFault;
                resultEnvelope.IsSuccess = isSuccess;
            }
        }

        return resultEnvelope;
    }

    //public static SoapEnvelope CreateSoapTypedResponse<T>(SoapEnvelope message) where T: class
    //{
    //    var resultEnvelope = new SoapEnvelope()
    //    {
    //        Header = new()
    //        {
    //            Action = Constants.Soap.Namespaces.Addressing,
    //        },
    //        Body = new SoapBody()
    //    };

    //    // Get property of SoapBody which matches T
    //    var propertyInfo = typeof(SoapBody).GetProperties()
    //        .FirstOrDefault(p => p.PropertyType == typeof(T));

    //    if (propertyInfo != null && propertyInfo.CanWrite)
    //    {
    //        var bodyProperty = message.Body.GetType().GetProperty(propertyInfo.Name);

    //        if (bodyProperty != null)
    //        {
    //            var value = bodyProperty.GetValue(message.Body);

    //            propertyInfo.SetValue(resultEnvelope.Body, value);
    //        }
    //    }

    //    return resultEnvelope;
    //}

    public static T DeepClone<T>(T obj)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (var memoryStream = new MemoryStream())
        {
            using (var writer = new StreamWriter(memoryStream))
            {
                serializer.Serialize(writer, obj);
                writer.Flush(); // Ensure all data is written

                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(memoryStream))
                {
                    return (T)serializer.Deserialize(reader)!;
                }
            }
        }
    }

    public static SoapHeader GetResponseHeaderFromRequest(SoapEnvelope envelope)
    {
        return new SoapHeader()
        {
            Action = envelope.GetCorrespondingResponseAction(),
        };
    }

    public static void PutRegistryResponseInTheCorrectPlaceAccordingToSoapAction(SoapEnvelope soapEnvelopeResponse, RegistryResponseType registryResponse)
    {
        switch (soapEnvelopeResponse.Header.Action)
        {
            case Constants.Xds.OperationContract.Iti18Reply:
            case Constants.Xds.OperationContract.Iti18ReplyAsync:
            case Constants.Xds.OperationContract.Iti38Reply:
            case Constants.Xds.OperationContract.Iti38ReplyAsync:
                soapEnvelopeResponse.Body ??= new();
                soapEnvelopeResponse.Body.AdhocQueryResponse ??= new();
                soapEnvelopeResponse.Body.AdhocQueryResponse.RegistryErrorList ??= new();
                soapEnvelopeResponse.Body.AdhocQueryResponse.RegistryErrorList = registryResponse.RegistryErrorList;
                soapEnvelopeResponse.Body.AdhocQueryResponse.Status = registryResponse.Status;
                break;

            default:
                soapEnvelopeResponse.Body ??= new();
                soapEnvelopeResponse.Body.RegistryResponse ??= new();
                soapEnvelopeResponse.Body.RegistryResponse = registryResponse;
                break;
        }
    }
}
