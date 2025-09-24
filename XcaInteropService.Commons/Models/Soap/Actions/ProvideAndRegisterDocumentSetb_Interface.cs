using System.ServiceModel;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Soap.Actions;

// ITI-41
[ServiceContract(Namespace = "urn:ihe:iti:xds-b:2007", ConfigurationName = "DocumentSharing.Xds.IProvideAndRegisterDocumentSetb")]
public interface IProvideAndRegisterDocumentSetb
{
    [OperationContract(Action = "urn:ihe:iti:2007:ProvideAndRegisterDocumentSet-b", ReplyAction = "urn:ihe:iti:2007:ProvideAndRegisterDocumentSet-bResponse")]
    [XmlSerializerFormat(SupportFaults = true)]
    [ServiceKnownType(typeof(RegistryRequestType))]
    ProvideAndRegisterDocumentSetbResponse ProvideAndRegisterDocumentSetb(ProvideAndRegisterDocumentSetbRequest request);

    [OperationContract(Action = "urn:ihe:iti:2007:ProvideAndRegisterDocumentSet-b", ReplyAction = "urn:ihe:iti:2007:ProvideAndRegisterDocumentSet-bResponse")]
    Task<ProvideAndRegisterDocumentSetbResponse> ProvideAndRegisterDocumentSetbAsync(ProvideAndRegisterDocumentSetbRequest request);
}

public interface IProvideAndRegisterDocumentSetbChannel : IProvideAndRegisterDocumentSetb, IClientChannel
{
}
