using System.Xml.Schema;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;


[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Svs)]
public class ConceptListType
{
    [XmlAttribute(AttributeName = "lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang;

    [XmlElement(Order = 0)]
    public ConceptType[] Concept;
}
