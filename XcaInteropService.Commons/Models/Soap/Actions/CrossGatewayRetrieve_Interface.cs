using System.ServiceModel;

namespace XcaInteropService.Commons.Models.Soap.Actions;

// ITI-39
[ServiceContract(Namespace = "urn:ihe:iti:xds-b:2007", ConfigurationName = "DocumentSharing.Xds.ICrossGatewayRetrieve")]
public interface ICrossGatewayRetrieve
{
    [OperationContract(Action = "urn:ihe:iti:2007:CrossGatewayRetrieve", ReplyAction = "urn:ihe:iti:2007:CrossGatewayRetrieveResponse")]
    [XmlSerializerFormat(SupportFaults = true)]
    CrossGatewayRetrieveResponse CrossGatewayRetrieve(CrossGatewayRetrieveRequest request);

    [OperationContract(Action = "urn:ihe:iti:2007:CrossGatewayRetrieve", ReplyAction = "urn:ihe:iti:2007:CrossGatewayRetrieveResponse")]
    Task<CrossGatewayRetrieveResponse> CrossGatewayRetrieveAsync(CrossGatewayRetrieveRequest request);
}

public interface ICrossGatewayRetrieveChannel : ICrossGatewayRetrieve, IClientChannel
{
}
