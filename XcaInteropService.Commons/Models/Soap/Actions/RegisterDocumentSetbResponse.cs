using System.ServiceModel;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Soap.Actions;

[MessageContract(IsWrapped = false)]
public class RegisterDocumentSetbResponse
{
    [MessageBodyMember(Namespace = Constants.Xds.Namespaces.Rs, Order = 0)]
    public RegistryResponseType RegistryResponse;

    public RegisterDocumentSetbResponse()
    {
    }

    public RegisterDocumentSetbResponse(RegistryResponseType registryResponse)
    {
        RegistryResponse = registryResponse;
    }
}
