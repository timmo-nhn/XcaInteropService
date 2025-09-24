using System.ServiceModel;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Soap.Actions;

// ITI-43
[ServiceContract(Namespace = "urn:ihe:iti:xds-b:2007", ConfigurationName = "DocumentSharing.Xds.IRetrieveDocumentSet")]
public interface IRetrieveDocumentSet
{
    [OperationContract(Action = "urn:ihe:iti:2007:RetrieveDocumentSet", ReplyAction = "urn:ihe:iti:2007:RetrieveDocumentSetResponse")]
    [XmlSerializerFormat(SupportFaults = true)]
    SoapEnvelope RetrieveDocumentSet(DocumentRequestType[] request);

    [OperationContract(Action = "urn:ihe:iti:2007:RetrieveDocumentSet", ReplyAction = "urn:ihe:iti:2007:RetrieveDocumentSetResponse")]
    Task<RetrieveDocumentSetResponseType> RetrieveDocumentSetAsync(DocumentRequestType[] request);
}