using System.ServiceModel;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Soap.Actions;

// ITI-18
[ServiceContract(Namespace = "urn:ihe:iti:xds-b:2007", ConfigurationName = "DocumentSharing.Xds.IRegistryStoredQuery")]
public interface IRegistryStoredQuery
{
    [OperationContract(Action = "urn:ihe:iti:2007:RegistryStoredQuery", ReplyAction = "urn:ihe:iti:2007:RegistryStoredQueryResponse")]
    [XmlSerializerFormat(SupportFaults = true)]
    [ServiceKnownType(typeof(RegistryResponseType))]
    [ServiceKnownType(typeof(RegistryRequestType))]
    [ServiceKnownType(typeof(RegistryPackageType))]
    RegistryStoredQueryResponse RegistryStoredQuery(RegistryStoredQueryRequest request);

    [OperationContract(Action = "urn:ihe:iti:2007:RegistryStoredQuery", ReplyAction = "urn:ihe:iti:2007:RegistryStoredQueryResponse")]
    Task<RegistryStoredQueryResponse> RegistryStoredQueryAsync(RegistryStoredQueryRequest request);
}