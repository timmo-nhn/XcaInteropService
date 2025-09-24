using System.Globalization;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.ClinicalDocument.Types;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Hl7V3)]
public class TS : ANY
{
    [XmlIgnore]
    public DateTimeOffset EffectiveTime { get; set; } = default;

    private string _dateFormat;

    [XmlIgnore]
    private string? RawEffectiveTimeValue { get; set; }

    [XmlAttribute("value")]
    public string? Value
    {
        get
        {
            return _dateFormat != null ? EffectiveTime.ToString(_dateFormat) : RawEffectiveTimeValue;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value)) return;

            bool matched = false;

            foreach (var dateFormat in Constants.Hl7.Dtm.AllFormats)
            {
                if (DateTimeOffset.TryParseExact(value, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTimeOffset))
                {
                    _dateFormat = dateFormat;
                    EffectiveTime = dateTimeOffset;
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                _dateFormat = null;
                RawEffectiveTimeValue = value;
            }
        }
    }

    public bool ShouldSerializeEffectiveTimeValue()
    {
        // Serialize the value only if a valid date format was found
        return _dateFormat != null || !string.IsNullOrWhiteSpace(RawEffectiveTimeValue);
    }
}
