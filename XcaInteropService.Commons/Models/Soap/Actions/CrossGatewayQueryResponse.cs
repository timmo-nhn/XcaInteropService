using System.ComponentModel;
using System.ServiceModel;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Soap.Actions;

[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class CrossGatewayQueryResponse
{
    [MessageBodyMember(Namespace = Constants.Xds.Namespaces.Query, Order = 0)]
    public AdhocQueryResponse AdhocQueryResponse;

    public CrossGatewayQueryResponse()
    {
    }

    public CrossGatewayQueryResponse(AdhocQueryResponse adhocQueryResponse)
    {
        AdhocQueryResponse = adhocQueryResponse;
    }
}
