using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public partial class AdhocQueryType : RegistryObjectType
{
    [XmlElement(Order = 0)]
    public QueryExpressionType? QueryExpression;
}
