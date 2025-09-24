using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Xdsb)]
public class RegisterDocumentSetRequestType
{
    [XmlElement(Namespace = Constants.Xds.Namespaces.Lcm, Order = 0)]
    public SubmitObjectsRequest SubmitObjectsRequest;
}
