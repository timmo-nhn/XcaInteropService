using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[XmlInclude(typeof(NotifyActionType))]
[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public abstract class ActionType
{
}
