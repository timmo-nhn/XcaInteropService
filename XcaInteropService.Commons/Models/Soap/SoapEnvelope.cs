using System.Xml;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.Actions;
using XcaInteropService.Commons.Models.Soap.XdsTypes;
using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Commons.Models.Soap;

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
[XmlInclude(typeof(RegistryStoredQueryRequest))]
[XmlInclude(typeof(ProvideAndRegisterDocumentSetbRequest))]
[XmlInclude(typeof(RegisterDocumentSetbRequest))]
[XmlInclude(typeof(SubmitObjectsRequest))]
[XmlInclude(typeof(IdentifiableType))]
[XmlInclude(typeof(RegistryResponseType))]
[XmlInclude(typeof(RetrieveDocumentSetResponseType))]
[XmlInclude(typeof(RetrieveDocumentSetbResponse))]
[XmlInclude(typeof(RetrieveDocumentSetbRequest))]
[XmlRoot("Envelope", Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
public class SoapEnvelope
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public SoapHeader Header { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public SoapBody Body { get; set; }

    public void SetAction(string action)
    {
        Header.Action = action;
    }
    public string GetCorrespondingResponseAction()
    {
        return Header?.Action switch
        {
            Constants.Xds.OperationContract.Iti18Action => Constants.Xds.OperationContract.Iti18Reply,
            Constants.Xds.OperationContract.Iti41Action => Constants.Xds.OperationContract.Iti41Reply,
            Constants.Xds.OperationContract.Iti42Action => Constants.Xds.OperationContract.Iti42Reply,
            Constants.Xds.OperationContract.Iti43Action => Constants.Xds.OperationContract.Iti43Reply,
            Constants.Xds.OperationContract.Iti38Action => Constants.Xds.OperationContract.Iti38Reply,
            Constants.Xds.OperationContract.Iti38ActionAsync => Constants.Xds.OperationContract.Iti38Reply,
            Constants.Xds.OperationContract.Iti39Action => Constants.Xds.OperationContract.Iti39Reply,
            Constants.Xds.OperationContract.Iti39ActionAsync => Constants.Xds.OperationContract.Iti39Reply,
            Constants.Xds.OperationContract.Iti62Action => Constants.Xds.OperationContract.Iti62Reply,
            Constants.Xds.OperationContract.Iti86Action => Constants.Xds.OperationContract.Iti86Reply,
            _ => string.Empty
        };
    }

    public string GetCorrespondingRequestAction()
    {
        return Header.Action switch
        {
            Constants.Xds.OperationContract.Iti18Reply => Constants.Xds.OperationContract.Iti18Action,
            Constants.Xds.OperationContract.Iti41Reply => Constants.Xds.OperationContract.Iti41Action,
            Constants.Xds.OperationContract.Iti42Reply => Constants.Xds.OperationContract.Iti42Action,
            Constants.Xds.OperationContract.Iti43Reply => Constants.Xds.OperationContract.Iti43Action,
            Constants.Xds.OperationContract.Iti38Reply => Constants.Xds.OperationContract.Iti38Action,
            Constants.Xds.OperationContract.Iti39Reply => Constants.Xds.OperationContract.Iti39Action,
            Constants.Xds.OperationContract.Iti62Reply => Constants.Xds.OperationContract.Iti62Action,
            Constants.Xds.OperationContract.Iti86Reply => Constants.Xds.OperationContract.Iti86Action,
            _ => string.Empty
        };
    }

    public SoapEnvelope? DeepCopy()
    {
        var sxmls = new SoapXmlSerializer();
        var soapSerializeResult = sxmls.SerializeToXmlString(this);
        if (soapSerializeResult.Content != null && soapSerializeResult.IsSuccess)
        {
            return sxmls.DeserializeXmlString<SoapEnvelope>(soapSerializeResult.Content);
        }
        return null;
    }
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
public partial class SoapBody
{
    [SoapAttribute("type", Namespace = Constants.Soap.Namespaces.Xsi)]
    public string? XsiType { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Query)]
    public AdhocQueryRequest? AdhocQueryRequest { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Query)]
    public AdhocQueryResponse? AdhocQueryResponse { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb)]
    public ProvideAndRegisterDocumentSetRequestType? ProvideAndRegisterDocumentSetRequest { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb)]
    public ProvideAndRegisterDocumentSetbResponse? ProvideAndRegisterDocumentSetResponse { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb)]
    public RegisterDocumentSetRequestType? RegisterDocumentSetRequest { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb)]
    public RegistryResponseType? RegisterDocumentSetResponse { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb)]
    public RetrieveDocumentSetbRequest? RetrieveDocumentSetRequest { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb)]
    public RetrieveDocumentSetResponseType? RetrieveDocumentSetResponse { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Rs)]
    public RegistryResponseType? RegistryResponse { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Lcm)]
    public RemoveObjectsRequestType? RemoveObjectsRequest { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Rmd)]
    public RemoveDocumentsRequestType? RemoveDocumentsRequest { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Rmd)]
    public RetrieveValueSetRequest? RetrieveValueSetRequest { get; set; }

    [XmlElement(Namespace = Constants.Xds.Namespaces.Rmd)]
    public RetrieveValueSetResponse? RetrieveValueSetResponse { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public Fault? Fault { get; set; }
}


[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Soap.Namespaces.Xsi)]
public class SoapHeader
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.Addressing)]
    public string? Action { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.Addressing)]
    public string? RelatesTo { get; set; }

    [XmlElement("MessageID", Namespace = Constants.Soap.Namespaces.Addressing)]
    public string? MessageId { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.Addressing)]
    public string? To { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.Addressing)]
    public SoapReplyTo? ReplyTo { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.Addressing)]
    public SoapFaultTo? FaultTo { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.SecurityExt)]
    public Security? Security { get; set; }
}


[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Soap.Namespaces.Xsi)]
public class SoapFaultTo
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.Addressing)]
    public string Address = "http://www.w3.org/2005/08/addressing/anonymous";
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Soap.Namespaces.Xsi)]
public class SoapReplyTo
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.Addressing)]
    public string Address = "http://www.w3.org/2005/08/addressing/anonymous";
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Soap.Namespaces.SecurityExt)]
public class Security
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.SecurityUtility)]
    public SoapTimestamp? Timestamp { get; set; }

    [XmlAnyElement(Namespace = Constants.Soap.Namespaces.Saml2)]
    public XmlElement? Assertion { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Soap.Namespaces.SecurityExt)]
public partial class SoapTimestamp
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.SecurityUtility)]
    public string Created { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.SecurityUtility)]
    public string Expires { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Constants.Soap.Namespaces.SecurityExt)]
public partial class Assertion
{

}


[Serializable]
[XmlType(AnonymousType = true)]
public class Fault
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public Code Code { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public Reason Reason { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public Detail? Detail { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true)]
public class Code
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public string Value { get; set; }

    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public Subcode? Subcode { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true)]
public class Detail
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.Addressing)]
    public ProblemAction Value { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true)]
public class ProblemAction
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.Addressing)]
    public string Action { get; set; }
}


[Serializable]
[XmlType(AnonymousType = true)]
public class Subcode
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public string Value { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true)]
public class Reason
{
    [XmlElement(Namespace = Constants.Soap.Namespaces.SoapEnvelope)]
    public string Text { get; set; }
}
