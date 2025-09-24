using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Extensions;

public static class AssociationExtensions
{
    /// <summary>
    /// Mark ExtrinsicObject as Deprecated. Will not show up in ITI-18 requests
    /// </summary>
    public static void DeprecateDocumentEntry(
        this IEnumerable<IdentifiableType> source, string id, out bool success)
    {
        success = false;
        if (id == null) return;
        var documentEntryToDeprecate = source.OfType<ExtrinsicObjectType>().Where(eo => eo.Id == id);

        if (!documentEntryToDeprecate.Any()) return;

        foreach (var entry in documentEntryToDeprecate)
        {
            entry.Status = Constants.Xds.StatusValues.Deprecated;
            success = true;
        }
    }


}
