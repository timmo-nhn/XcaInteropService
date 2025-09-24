using System.ComponentModel;
using System.ServiceModel;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Soap.Actions;

[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class CrossGatewayQueryRequest
{
    [MessageBodyMember(Namespace = Constants.Xds.Namespaces.Query, Order = 0)]
    public AdhocQueryRequest AdhocQueryRequest;

    public CrossGatewayQueryRequest()
    {
    }

    public CrossGatewayQueryRequest(AdhocQueryRequest adhocQueryRequest)
    {
        AdhocQueryRequest = adhocQueryRequest;
    }
}
