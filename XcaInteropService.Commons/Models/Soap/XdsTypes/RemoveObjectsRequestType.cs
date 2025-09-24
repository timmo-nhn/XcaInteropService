using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class RemoveObjectsRequestType
{
    [XmlElement("ObjectRefList", Order = 0)]
    public ObjectRefList? ObjectRefList { get; set; }
}

