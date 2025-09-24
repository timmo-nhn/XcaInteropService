using System.Xml.Serialization;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlInclude(typeof(Act))]
[XmlInclude(typeof(Encounter))]
[XmlInclude(typeof(Observation))]
[XmlInclude(typeof(ObservationMedia))]
[XmlInclude(typeof(Organizer))]
[XmlInclude(typeof(Procedure))]
[XmlInclude(typeof(RegionOfInterest))]
[XmlInclude(typeof(SubstanceAdministration))]
[XmlInclude(typeof(Supply))]
public class EntryItemBase
{

}