using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Extensions;

public static class SoapExtensions
{
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

    public static string GetHighestSeverityErrorFromSoapEnvelope(SoapEnvelope soapEnvelope)
    {
        var errorList = soapEnvelope.Body.RegistryResponse?.RegistryErrorList?.RegistryError;
        if (errorList == null || errorList.Length == 0)
        {
            return null;
        }

        if (errorList.Any(e => e.Severity.Contains("Error")))
        {
            return Constants.Xds.ErrorSeverity.Error;
        }
        else if (errorList.Any(e => e.Severity.Contains("Warning")))
        {
            return Constants.Xds.ErrorSeverity.Warning;
        }

        return Constants.Xds.ErrorSeverity.Warning;
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
