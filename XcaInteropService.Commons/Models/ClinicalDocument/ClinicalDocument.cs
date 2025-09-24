using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;

namespace XcaInteropService.Commons.Models.ClinicalDocument;

[Serializable]
[XmlRoot(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class ClinicalDocument
{
    [XmlAttribute("classCode")]
    public string? classCode { get; set; }

    [XmlAttribute("moodCode")]
    public string? moodCode { get; set; }

    [XmlElement("realmCode")]
    public List<CS>? RealmCode { get; set; }

    [XmlElement("typeId")]
    public II TypeId { get; set; }

    [XmlElement("templateId")]
    public List<II>? TemplateId { get; set; }

    [XmlElement("id")]
    public II Id { get; set; }

    [XmlElement("code")]
    public CV Code { get; set; }

    [XmlElement("title")]
    public string? Title { get; set; }

    [XmlElement("effectiveTime")]
    public TS EffectiveTime { get; set; }

    [XmlElement("confidentialityCode")]
    public CV ConfidentialityCode { get; set; }

    [XmlElement("languageCode")]
    public CS? LanguageCode { get; set; }

    [XmlElement("setId")]
    public II? SetId { get; set; }

    [XmlElement("versionNumber")]
    public INT? VersionNumber { get; set; }

    [XmlElement("copyTime")]
    public TS? CopyTime { get; set; }

    [XmlElement("recordTarget")]
    public List<RecordTarget> RecordTarget { get; set; }

    [XmlElement("author")]
    public List<Author> Author { get; set; }

    [XmlElement("dataEnterer")]
    public DataEnterer? DataEnterer { get; set; }

    [XmlElement("informant")]
    public List<Informant>? Informant { get; set; }

    [XmlElement("custodian")]
    public Custodian Custodian { get; set; }

    [XmlElement("informationRecipient")]
    public List<InformationRecipient>? InformationRecipient { get; set; }

    [XmlElement("legalAuthenticator")]
    public LegalAuthenticator LegalAuthenticator { get; set; }

    [XmlElement("authenticator")]
    public List<Authenticator>? Authenticator { get; set; }

    [XmlElement("participant")]
    public List<Participant1>? Participant { get; set; }

    [XmlElement("inFulfillmentOf")]
    public List<InFulfillmentOf>? InFulfillmentOf { get; set; }

    [XmlElement("documentationOf")]
    public List<DocumentationOf>? DocumentationOf { get; set; }

    [XmlElement("relatedDocument")]
    public List<RelatedDocument>? RelatedDocument { get; set; }

    [XmlElement("authorization")]
    public List<Authorization>? Authorization { get; set; }

    [XmlElement("componentOf")]
    public ComponentOf? ComponentOf { get; set; }

    [XmlElement("component")]
    public Component Component { get; set; }
}