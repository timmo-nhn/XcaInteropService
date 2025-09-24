using System.ComponentModel;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Rim)]
public class VersionInfoType
{
    public VersionInfoType()
    {
        VersionName = "1.1";
    }

    [XmlAttribute(AttributeName = "versionName")]
    [DefaultValue("1.1")]
    public string VersionName;

    [XmlAttribute(AttributeName = "comment")]
    public string Comment;

}
