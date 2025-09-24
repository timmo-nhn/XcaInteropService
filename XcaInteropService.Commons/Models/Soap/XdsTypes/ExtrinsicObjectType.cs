using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Hl7.DataType;
using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType("ExtrinsicObject", Namespace = Constants.Xds.Namespaces.Rim)]
public partial class ExtrinsicObjectType : RegistryObjectType
{
    public ExtrinsicObjectType()
    {
        MimeType = Constants.MimeTypes.Binary;
        IsOpaque = false;
    }

    [XmlElement(Order = 0)]
    public VersionInfoType ContentVersionInfo;

    [XmlElement(Namespace = Constants.Xds.Namespaces.Xdsb, DataType = "base64Binary", Order = 1)]
    public byte[] Document;

    [XmlAttribute(AttributeName = "mimeType")]
    [DefaultValue(Constants.MimeTypes.Binary)]
    public string MimeType;

    [XmlAttribute(AttributeName = "isOpaque")]
    [DefaultValue(false)]
    public bool IsOpaque;

    public PID GetPatientIdentifiersFromExtrinsicObject()
    {
        var patientPid = new PID();
        patientPid.PatientIdentifier ??= new();

        var patientId = this.ExternalIdentifier.FirstOrDefault(x => x.IdentificationScheme == Constants.Xds.Uuids.DocumentEntry.PatientId)?.Value;

        var sourcePatientInfo = this.Slot?
        .FirstOrDefault(s => s.Name == Constants.Xds.SlotNames.SourcePatientInfo)?.ValueList?.Value?
        .ToList() ?? new List<string>();

        patientPid.PatientIdentifier = Hl7Object.Parse<CX>(patientId);

        foreach (var pidPart in sourcePatientInfo)
        {
            if (pidPart.Contains("PID-5"))
            {
                var value = pidPart.Substring(pidPart.IndexOf("|") + 1);
                patientPid.PatientName = Hl7Object.Parse<XPN>(value);
            }
            if (pidPart.Contains("PID-7"))
            {
                var value = pidPart.Substring(pidPart.IndexOf("|") + 1);
                patientPid.BirthDate = DateTime.ParseExact(value, Constants.Hl7.Dtm.AllFormats, CultureInfo.InvariantCulture);
            }
            if (pidPart.Contains("PID-8"))
            {
                var value = pidPart.Substring(pidPart.IndexOf("|") + 1);
                patientPid.Gender = value;
            }
        }
        return patientPid;

    }

}
