using System.ServiceModel;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Soap.Actions;

// ITI-42
[ServiceKnownType(typeof(RegistryResponseType))]
[ServiceKnownType(typeof(RegistryRequestType))]
[ServiceKnownType(typeof(RegistryPackageType))]
[ServiceContract(Namespace = "urn:ihe:iti:xds-b:2007", ConfigurationName = "DocumentSharing.Xds.IRegisterDocumentSetb")]
public interface IRegisterDocumentSetb
{
    [OperationContract(Action = "urn:ihe:iti:2007:RegisterDocumentSet-b", ReplyAction = "urn:ihe:iti:2007:RegisterDocumentSet-bResponse")]
    [XmlSerializerFormat(SupportFaults = true)]
    SoapEnvelope RegisterDocumentSetb(SubmitObjectsRequest request);

    [OperationContract(Action = "urn:ihe:iti:2007:RegisterDocumentSet-b", ReplyAction = "urn:ihe:iti:2007:RegisterDocumentSet-bResponse")]
    Task<SoapEnvelope> RegisterDocumentSetbAsync(SubmitObjectsRequest request);
}

public interface IRegisterDocumentSetbChannel : IRegisterDocumentSetb, IClientChannel
{
}
