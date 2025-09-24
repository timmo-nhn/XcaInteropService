using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Xdsb)]
public class DocumentRequestType
{
    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb, Order = 0)]
    public string? HomeCommunityId;

    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb, Order = 1)]
    public string? RepositoryUniqueId;

    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb, Order = 2)]
    public string? DocumentUniqueId;
}
