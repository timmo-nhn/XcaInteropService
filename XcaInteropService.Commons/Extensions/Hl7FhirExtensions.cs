using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Commons.Models.Hl7.DataType;

namespace XcaInteropService.Commons.Extensions;

public static class Hl7FhirExtensions
{
    public static DateRange GetDateTimeRangeFromDateParameters(string timingAndDate)
    {
        timingAndDate = timingAndDate.Replace("%3A", ":");
        var modifier = timingAndDate.Substring(0, 2);
        var date = timingAndDate.Substring(2);
        var datetime = DateTime.Parse(date);

        switch (modifier)
        {
            case "eq":
                var queryInstantEq = DateTime.Parse(date);
                return new DateRange(queryInstantEq, queryInstantEq.AddDays(1).Trim(TimeSpan.TicksPerDay).AddTicks(-1));

            case "gt":
                var queryInstantGt = DateTime.Parse(date);
                return new DateRange(queryInstantGt, null);

            case "lt":
                var queryInstantLt = DateTime.Parse(date);
                return new DateRange(null, queryInstantLt);

            case "ge":
                var queryInstantGe = DateTime.Parse(date);
                return new DateRange(queryInstantGe.AddTicks(-1), null);

            case "le":
                var queryInstantLe = DateTime.Parse(date);
                return new DateRange(null, queryInstantLe.AddTicks(-1));

            case "sa":
                var queryInstantSa = DateTime.Parse(date);
                return new DateRange(queryInstantSa, null);

            case "eb":
                var queryInstantEb = DateTime.Parse(date);
                return new DateRange(null, queryInstantEb.AddTicks(-1));

            case "ap":
                var queryInstantAp = DateTime.Parse(date);
                return new DateRange(queryInstantAp.AddDays(-10), queryInstantAp.AddDays(10));

            default:
                break;
        }


        throw new NotImplementedException();
    }

    static DateTime Trim(this DateTime date, long roundTicks)
    {
        return new DateTime(date.Ticks - date.Ticks % roundTicks, date.Kind);
    }

    /// <summary>
    /// Parse a National Identifier Number and get the birth date aswell as the proper assigning authority depending on whether its a Dnr, Hnr or Pnr/Fnr)
    /// </summary>
    public static CX? ParseNinToCxWithAssigningAuthority(string inputNin)
    {
        if (inputNin.Length != 11) return null;

        var day = inputNin.Substring(0, 2);
        var month = inputNin.Substring(2, 2);
        var year = inputNin.Substring(4, 2);
        var control = inputNin.Substring(6, 3);

        var oid = new HD()
        {
            UniversalIdType = Constants.Hl7.UniversalIdType.Iso,
            UniversalId = string.Empty
        };

        // Check if its a synthetic test-data Nin
        if (int.Parse(month) - 65 is > 0 and <= 12 || int.Parse(month) - 80 is > 0 and <= 12)
        {
            if (int.Parse(day) - 50 is > 0 and <= 31)
            {
                oid.UniversalId = Constants.Oid.Dnr;
            }
            else
            {
                oid.UniversalId = Constants.Oid.Fnr;
            }
        }

        // Normal D-number = +40 on day
        else if (int.Parse(day) - 40 is > 0 and <= 31)
        {
            oid.UniversalId = Constants.Oid.Dnr;
        }

        // Normal H-number = +40 on month
        else if (int.Parse(month) - 40 is > 0 and <= 12)
        {
            oid.UniversalId = Constants.Oid.Hnr;
        }
        else
        {
            oid.UniversalId = Constants.Oid.Fnr;
        }

        return new CX()
        {
            IdNumber = inputNin,
            AssigningAuthority = oid
        };
    }

}
