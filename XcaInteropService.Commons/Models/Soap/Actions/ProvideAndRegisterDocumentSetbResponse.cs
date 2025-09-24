using System.ComponentModel;
using System.ServiceModel;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Soap.Actions;

[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ProvideAndRegisterDocumentSetbResponse
{
    [MessageBodyMember(Namespace = Constants.Xds.Namespaces.Rs, Order = 0)]
    public RegistryResponseType RegistryResponse;

    public ProvideAndRegisterDocumentSetbResponse()
    {
    }

    public ProvideAndRegisterDocumentSetbResponse(RegistryResponseType registryResponse)
    {
        RegistryResponse = registryResponse;
    }
}
