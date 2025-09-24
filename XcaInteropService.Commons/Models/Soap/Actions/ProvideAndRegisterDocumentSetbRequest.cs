using System.ComponentModel;
using System.ServiceModel;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Soap.Actions;

[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public partial class ProvideAndRegisterDocumentSetbRequest
{
    [MessageBodyMember(Namespace = Constants.Xds.Namespaces.Xdsb, Order = 0)]
    public ProvideAndRegisterDocumentSetRequestType ProvideAndRegisterDocumentSetRequest;

    public ProvideAndRegisterDocumentSetbRequest()
    {
    }

    public ProvideAndRegisterDocumentSetbRequest(ProvideAndRegisterDocumentSetRequestType provideAndRegisterDocumentSetRequest)
    {
        ProvideAndRegisterDocumentSetRequest = provideAndRegisterDocumentSetRequest;
    }
}
