using System.Collections.Immutable;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Extensions;

/// <summary>
/// Extension-methods for filtering data based on search parameters specified in ITI-18 Registry Stored Query
/// Works with types in XcaXds.Commons.Models.Soap.XdsTypes 
/// Documentation on format and optionality: https://profiles.ihe.net/ITI/TF/Volume2/ITI-18.html#3.18.4.1.2.3.7
/// 
/// -- Numbered Parameter Names --
/// Docs:   https://profiles.ihe.net/ITI/TF/Volume2/ITI-18.html#3.18.4.1.2.3.4
/// [(1)]:  Field uses Abbreviated form of the HL7 V2.5 CE format (eg.: code^^coding-scheme)
/// [(3)]:  Field supports AND/OR semantics
/// [(4)]:  Field supports SQL-LIKE (% and _) syntax for wildcard search
///             - Underscore ('_') matches an arbitrary character
///             - Percent('%') matches an arbitrary string (0 or more characters)
/// 
/// -- Table Format used for the tables above each method --
/// Parameter Name:     Part of the request (ITI-18)
/// Attribute:          Part of the Document Registry Object    
///
/// Opt(Optionality):   [R]=Required, [O]=Optional
/// Mult(Multiple):     [-]=zero or one, [M]=zero or many
/// When a property has Mult value [M], the method input is a list<string[]> If not ([-]), its just string
///
/// -- Table Example --
/// | Parameter Name (ITI-18)          | Attribute                   | Opt | Mult |
/// |----------------------------------|-----------------------------|-----|------|
/// | $XDSDocumentEntryPatientId(1|3|4)| XDSDocumentEntry.patientId  | R|O | —|M  |
/// </summary>
public static class FindDocuments
{
    /// | Parameter Name (ITI-18)      | Attribute                   | Opt | Mult |
    /// |------------------------------|-----------------------------|-----|------|
    /// | $XDSDocumentEntryPatientId   | XDSDocumentEntry.patientId  | R   | —    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryPatientId(
        this IEnumerable<ExtrinsicObjectType> source, string? patientId)
    {
        if (string.IsNullOrWhiteSpace(patientId)) return Enumerable.Empty<ExtrinsicObjectType>();  // Required field, return nothing if not specified
        return source.Where(eo => eo.ExternalIdentifier.Any(ei =>
            ei.IdentificationScheme == Constants.Xds.Uuids.DocumentEntry.PatientId &&
            ei.Value == patientId));
    }

    /// | Parameter Name (ITI-18)       | Attribute                   | Opt | Mult |
    /// |-------------------------------|-----------------------------|-----|------|
    /// | $XDSDocumentEntryClassCode(1) | XDSDocumentEntry.classCode  | O   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryClassCode(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? classCodes)
    {
        if (classCodes == null || classCodes.Count == 0) return source; // Optional field, return everything if not specified
        return source.Where(eo => eo.Classification
            .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.DocumentEntry.ClassCode)
            .Select(cf => cf.NodeRepresentation + "^^" + cf.GetSlots(Constants.Xds.SlotNames.CodingScheme).FirstOrDefault()?.GetFirstValue())
            .All(co => classCodes.Any(cc => cc.Contains(co))));
    }

    /// | Parameter Name (ITI-18)      | Attribute                   | Opt | Mult |
    /// |------------------------------|-----------------------------|-----|------|
    /// | $XDSDocumentEntryTypeCode(1) | XDSDocumentEntry.typeCode   | O   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryTypeCode(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? typeCodes)
    {
        if (typeCodes == null || typeCodes.Count == 0) return source; // Optional field, return everything if not specified
        return source.Where(eo => eo.Classification
            .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.DocumentEntry.TypeCode)
            .Select(cf => cf.NodeRepresentation + "^^" + cf.GetSlots(Constants.Xds.SlotNames.CodingScheme).FirstOrDefault()?.GetFirstValue())
            .All(co => typeCodes.Any(cc => cc.Contains(co))));
    }

    /// | Parameter Name (ITI-18)                 | Attribute                             | Opt | Mult |
    /// |-----------------------------------------|---------------------------------------|-----|------|
    /// | $XDSDocumentEntryPracticeSettingCode(1) | XDSDocumentEntry.practiceSettingCode  | O   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryPracticeSettingCode(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? practiceSettingCodes)
    {
        if (practiceSettingCodes == null || practiceSettingCodes.Count == 0) return source; // Optional field, return everything if not specified
        return source.Where(eo => eo.Classification
            .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.DocumentEntry.ClassCode)
            .Select(cf => cf.NodeRepresentation + "^^" + cf.GetSlots(Constants.Xds.SlotNames.CodingScheme).FirstOrDefault()?.GetFirstValue())
            .All(co => practiceSettingCodes.Any(cc => cc.Contains(co))));
    }

    /// | Parameter Name (ITI-18)            | Attribute                                     | Opt | Mult |
    /// |------------------------------------|-----------------------------------------------|-----|------|
    /// | $XDSDocumentEntryCreationTimeFrom  | Lower value of XDSDocumentEntry.creationTime  | O   | -    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryCreationTimeFrom(
        this IEnumerable<ExtrinsicObjectType> source, string? creationTimeFrom)
    {
        if (string.IsNullOrWhiteSpace(creationTimeFrom)) return source;  // Optional field, return everything if not specified
        var dateTime = DateTime.ParseExact(creationTimeFrom, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture);

        return source.Where(eo =>
            eo.GetSlots(Constants.Xds.SlotNames.CreationTime)?.GetValues()?
            .Select(dt => DateTime.ParseExact(dt, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture))
            .Any(parsedDt => parsedDt >= dateTime) == true);
    }

    /// | Parameter Name (ITI-18)            | Attribute                                     | Opt | Mult |
    /// |------------------------------------|-----------------------------------------------|-----|------|
    /// | $XDSDocumentEntryCreationTimeTo    | Upper value of XDSDocumentEntry.creationTime  | O   | -    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryCreationTimeTo(
       this IEnumerable<ExtrinsicObjectType> source, string? creationTimeFrom)
    {
        if (string.IsNullOrWhiteSpace(creationTimeFrom)) return source;  // Optional field, return everything if not specified
        var dateTime = DateTime.ParseExact(creationTimeFrom, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture);

        return source.Where(eo =>
            eo.GetSlots(Constants.Xds.SlotNames.CreationTime)?.GetValues()?
            .Select(dt => DateTime.ParseExact(dt, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture))
            .Any(parsedDt => parsedDt <= dateTime) == true);
    }


    /// | Parameter Name (ITI-18)               | Attribute                                         | Opt | Mult |
    /// |---------------------------------------|---------------------------------------------------|-----|------|
    /// | $XDSDocumentEntryServiceStartTimeFrom | Lower value of XDSDocumentEntry.serviceStartTime  | O   | -    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryServiceStartTimeFrom(
        this IEnumerable<ExtrinsicObjectType> source, string? startTimeFrom)
    {
        if (string.IsNullOrWhiteSpace(startTimeFrom)) return source;  // Optional field, return everything if not specified
        var dateTime = DateTime.ParseExact(startTimeFrom, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture);

        return source.Where(eo =>
            eo.GetSlots(Constants.Xds.SlotNames.ServiceStartTime)?.GetValues()?
            .Select(dt => DateTime.ParseExact(dt, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture))
            .Any(parsedDt => parsedDt >= dateTime) == true);
    }

    /// | Parameter Name (ITI-18)             | Attribute                                        | Opt | Mult |
    /// |-------------------------------------|--------------------------------------------------|-----|------|
    /// | $XDSDocumentEntryServiceStartTimeTo | Upper value of XDSDocumentEntry.serviceStartTime | O   | —    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryServiceStartTimeTo(
        this IEnumerable<ExtrinsicObjectType> source, string? startTimeTo)
    {
        if (string.IsNullOrWhiteSpace(startTimeTo)) return source;  // Optional field, return everything if not specified
        var dateTime = DateTime.ParseExact(startTimeTo, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture);

        return source.Where(eo =>
            eo.GetSlots(Constants.Xds.SlotNames.ServiceStartTime)?.GetValues()?
            .Select(dt => DateTime.ParseExact(dt, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture))
            .Any(parsedDt => parsedDt <= dateTime) == true);
    }

    /// | Parameter Name (ITI-18)              | Attribute                                        | Opt | Mult |
    /// |--------------------------------------|--------------------------------------------------|-----|------|
    /// | $XDSDocumentEntryServiceStopTimeFrom | Lower value of XDSDocumentEntry.serviceStartTime | O   | —    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryServiceStopTimeFrom(
        this IEnumerable<ExtrinsicObjectType> source, string? stopTimeFrom)
    {
        if (string.IsNullOrWhiteSpace(stopTimeFrom)) return source;  // Optional field, return everything if not specified
        var dateTime = DateTime.ParseExact(stopTimeFrom, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture);

        return source.Where(eo =>
            eo.GetSlots(Constants.Xds.SlotNames.ServiceStopTime)?.GetValues()?
            .Select(dt => DateTime.ParseExact(dt, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture))
            .Any(parsedDt => parsedDt >= dateTime) == true);
    }

    /// | Parameter Name (ITI-18)            | Attribute                                       | Opt | Mult |
    /// |------------------------------------|-------------------------------------------------|-----|------|
    /// | $XDSDocumentEntryServiceStopTimeTo | Upper value of XDSDocumentEntry.serviceStopTime | O   | —    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryServiceStopTimeTo(
        this IEnumerable<ExtrinsicObjectType> source, string? stopTimeTo)
    {
        if (string.IsNullOrWhiteSpace(stopTimeTo)) return source;  // Optional field, return everything if not specified
        var dateTime = DateTime.ParseExact(stopTimeTo, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture);

        return source.Where(eo =>
            eo.GetSlots(Constants.Xds.SlotNames.ServiceStopTime)?.GetValues()?
            .Select(dt => DateTime.ParseExact(dt, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture))
            .Any(parsedDt => parsedDt <= dateTime) == true);
    }

    /// | Parameter Name (ITI-18)                           | Attribute                                   | Opt | Mult |
    /// |---------------------------------------------------|---------------------------------------------|-----|------|
    /// | $XDSDocumentEntryHealthcareFacilityTypeCode(1)(3) | XDSDocumentEntry.healthcareFacilityTypeCode | O   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryHealthcareFacilityTypeCode(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? healthcareFacilityTypeCodes)
    {
        if (healthcareFacilityTypeCodes == null || healthcareFacilityTypeCodes.Count == 0) return source; // Optional field, return everything if not specified
        return source.Where(eo => eo.Classification
            .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.DocumentEntry.ClassCode)
            .Select(cf => cf.NodeRepresentation + "^^" + cf.GetSlots(Constants.Xds.SlotNames.CodingScheme).FirstOrDefault()?.GetFirstValue())
            .All(hcfTypeCode => healthcareFacilityTypeCodes.Any(hcfTypeCodes => hcfTypeCodes.Contains(hcfTypeCode))));
    }

    /// | Parameter Name (ITI-18)              | Attribute                      | Opt | Mult |
    /// |--------------------------------------|--------------------------------|-----|------|
    /// | $XDSDocumentEntryEventCodeList(1)(3) | XDSDocumentEntry.eventCodeList | O   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryEventCodeList(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? eventCodeList)
    {
        if (eventCodeList == null || eventCodeList.Count == 0) return source; // Optional field, return everything if not specified

        return source.Where(eo =>
        {
            // Get all the confidentiality codes for the current ExtrinsicObject (eo)
            var eventCodesForExtrinsicObject = eo.Classification
                .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.DocumentEntry.EventCodeList)
                .Select(cf => cf.NodeRepresentation + "^^" + cf.GetSlots(Constants.Xds.SlotNames.CodingScheme).FirstOrDefault()?.GetFirstValue())
                .ToArray();

            return eventCodeList.All(singleEventCodeList =>
                singleEventCodeList.Any(eventCode => eventCodesForExtrinsicObject.Contains(eventCode))
            );
        });
    }

    /// | Parameter Name (ITI-18)                    | Attribute                            | Opt | Mult |
    /// |--------------------------------------------|--------------------------------------|-----|------|
    /// | $XDSDocumentEntryConfidentialityCode(1)(3) | XDSDocumentEntry.confidentialityCode | O   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryConfidentialityCode(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? confidentialityGroups)
    {
        if (confidentialityGroups == null || confidentialityGroups.Count == 0) return source; // Optional field, return everything if not specified

        return source.Where(eo =>
        {
            // Get all the confidentiality codes for the current ExtrinsicObject (eo)
            var confidentialityCodesForExtrinsicObject = eo.Classification
                .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.DocumentEntry.ConfidentialityCode)
                .Select(cf => cf.NodeRepresentation + "^^" + cf.GetSlots(Constants.Xds.SlotNames.CodingScheme).FirstOrDefault()?.GetFirstValue())
                .ToArray();

            return confidentialityGroups.All(singleConfidentialityGroup =>
                singleConfidentialityGroup.Any(confCode => confidentialityCodesForExtrinsicObject.Contains(confCode))
            );
        });
    }

    /// | Parameter Name (ITI-18)              | Attribute               | Opt | Mult |
    /// |--------------------------------------|-------------------------|-----|------|
    /// | $XDSDocumentEntryAuthorPerson (3)(4) | XDSDocumentEntry.author | O   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryAuthorPerson(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? authorPersons)
    {
        if (authorPersons == null || authorPersons.Count == 0) return source; // Optional field, return everything if not specified

        return source.Where(eo =>
        {
            // Get all the author persons for the current ExtrinsicObject (eo)
            var authorsFromExtrinsicObject = eo.Classification
                .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.DocumentEntry.Author)
                .SelectMany(cf => cf.GetSlots(Constants.Xds.SlotNames.AuthorPerson)
                    .Select(s => s.GetFirstValue()))
                .ToArray();

            return authorPersons.All(authorPersonGroup =>
                authorPersonGroup.Any(authorPersonListFromInput =>
                    authorsFromExtrinsicObject.Any(author =>
                    {
                        var authorRegexPattern = Regex.Escape(authorPersonListFromInput)
                            .Replace("%", ".*") // [%]: Matches any string
                            .Replace("_", "."); // [_]: Matches any single chararcter

                        return Regex.IsMatch(author ?? string.Empty, $"^{authorRegexPattern}$");
                    })
                )
            );

        });
    }

    /// | Parameter Name (ITI-18)        | Attribute                   | Opt | Mult |
    /// |--------------------------------|-----------------------------|-----|------|
    /// | $XDSDocumentEntryFormatCode(1) | XDSDocumentEntry.formatCode | O   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentFormatCode(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? formatCodes)
    {
        if (formatCodes == null || formatCodes.Count == 0) return source; // Optional field, return everything if not specified
        return source.Where(rp =>
        {
            var formatCodesFromRegistryPackage = rp.Classification
                .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.DocumentEntry.FormatCode);

            return formatCodes.Any(formatCodeGroup =>
                formatCodeGroup.Any(formatCode =>
                    formatCodesFromRegistryPackage.Any(ct => formatCode == ct.NodeRepresentation)
                )
            );
        });
    }

    /// | Parameter Name (ITI-18) | Attribute                           | Opt | Mult |
    /// |-------------------------|-------------------------------------|-----|------|
    /// | $XDSDocumentEntryStatus | XDSDocumentEntry.availabilityStatus | R   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryStatus(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? statuses)
    {
        if (statuses.Count == 0) return Enumerable.Empty<ExtrinsicObjectType>();  // Required field, return nothing if not specified

        return source.Where(eo =>
            statuses.All(group => group.Any(status => status == eo.Status)) // AND logic for groups, OR logic inside groups
        );
    }

    /// | Parameter Name (ITI-18)   | Attribute                   | Opt | Mult |
    /// |---------------------------|-----------------------------|-----|------|
    /// | $XDSDocumentEntryType     | XDSDocumentEntry.objectType | O   | M    |
    public static IEnumerable<ExtrinsicObjectType> ByDocumentEntryType(
        this IEnumerable<ExtrinsicObjectType> source, List<string[]>? typeCodes)
    {
        // https://profiles.ihe.net/ITI/TF/Volume2/ITI-18.html#3.18.4.1.2.3.6.2
        // If no value is specified for DocumentEntryType, the value requesting only Stable Document Entries shall be assumed.
        if (typeCodes == null || typeCodes.Count == 0) return source.Where(eo => eo.ObjectType.NoUrn() == Constants.Xds.Uuids.DocumentEntry.StableDocumentEntries.NoUrn());

        return source.Where(eo => typeCodes.Any(tcArr => tcArr.Any(tc => tc.NoUrn() == eo.ObjectType.NoUrn())));
    }
}

public static class FindSubmissionSets
{
    /// | Parameter Name (ITI-18)    | Attribute                   | Opt | Mult |
    /// |----------------------------|-----------------------------|-----|------|
    /// | $XDSSubmissionSetPatientId | XDSSubmissionSet.patientId  | R   | -    |
    public static IEnumerable<RegistryPackageType> BySubmissionSetPatientId(
        this IEnumerable<RegistryPackageType> source, string? patientId)
    {
        if (string.IsNullOrWhiteSpace(patientId)) return Enumerable.Empty<RegistryPackageType>();  // Required field, return nothing if not specified
        return source.Where(eo => eo.ExternalIdentifier.Any(ei =>
            ei.IdentificationScheme == Constants.Xds.Uuids.SubmissionSet.PatientId &&
            ei.Value.Contains(patientId)));
    }

    /// | Parameter Name (ITI-18)    | Attribute                  | Opt | Mult |
    /// |----------------------------|----------------------------|-----|------|
    /// | $XDSSubmissionSetSourceId  | XDSSubmissionSet.sourceId  | O   | M    |
    public static IEnumerable<RegistryPackageType> BySubmissionSetSourceId(
        this IEnumerable<RegistryPackageType> source, List<string[]>? sourceIdLists)
    {
        if (sourceIdLists == null || sourceIdLists.Count == 0) return source;

        return source.Where(rp => rp.ExternalIdentifier
            .Where(ei => ei.IdentificationScheme == Constants.Xds.Uuids.SubmissionSet.SourceId)
            .Any(extId => sourceIdLists.Any(sourceIdArray => sourceIdArray.Contains(extId.Value))));
    }



    /// | Parameter Name (ITI-18)             | Attribute                                    | Opt | Mult |
    /// |-------------------------------------|----------------------------------------------|-----|------|
    /// | $XDSSubmissionSetSubmissionTimeFrom | XDSSubmissionSet.submissionTime Lower value  | O   | -    |    
    public static IEnumerable<RegistryPackageType> BySubmissionSetSubmissionTimeFrom(
        this IEnumerable<RegistryPackageType> source, string? submissionTimeFrom)
    {
        if (string.IsNullOrWhiteSpace(submissionTimeFrom)) return source;  // Optional field, return everything if not specified
        var dateTime = DateTime.ParseExact(submissionTimeFrom, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture);

        return source.Where(eo =>
            eo.GetSlots(Constants.Xds.SlotNames.SubmissionTime)?.GetValues()?
            .Select(dt => DateTime.ParseExact(dt, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture))
            .Any(parsedDt => parsedDt >= dateTime) == true);
    }

    /// | Parameter Name (ITI-18)           | Attribute                                    | Opt | Mult |
    /// |-----------------------------------|----------------------------------------------|-----|------|
    /// | $XDSSubmissionSetSubmissionTimeTo | XDSSubmissionSet.submissionTime Upper value  | O   | -    |    
    public static IEnumerable<RegistryPackageType> BySubmissionSetSubmissionTimeTo(
        this IEnumerable<RegistryPackageType> source, string? submissionTimeTo)
    {
        if (string.IsNullOrWhiteSpace(submissionTimeTo)) return source;  // Optional field, return everything if not specified
        var dateTime = DateTime.ParseExact(submissionTimeTo, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture);

        return source.Where(eo =>
            eo.GetSlots(Constants.Xds.SlotNames.SubmissionTime)?.GetValues()?
            .Select(dt => DateTime.ParseExact(dt, Constants.Hl7.Dtm.DtmFormat, CultureInfo.InvariantCulture))
            .Any(parsedDt => parsedDt <= dateTime) == true);
    }

    /// | Parameter Name (ITI-18)           | Attribute               | Opt | Mult |
    /// |-----------------------------------|-------------------------|-----|------|
    /// | $XDSSubmissionSetAuthorPerson (4) | XDSDocumentEntry.author | O   | -    |
    public static IEnumerable<RegistryPackageType> BySubmissionSetAuthorPerson(
        this IEnumerable<RegistryPackageType> source, string? authorPerson)
    {
        if (string.IsNullOrWhiteSpace(authorPerson)) return source; // Optional field, return everything if not specified

        return source.Where(eo =>
        {
            // Get all the author persons for the current ExtrinsicObject (eo)
            var authorsFromExtrinsicObject = eo.Classification
                .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.SubmissionSet.Author)
                .SelectMany(cf => cf.GetSlots(Constants.Xds.SlotNames.AuthorPerson)
                    .Select(s => s.GetFirstValue()))
                .ToArray();

            return authorsFromExtrinsicObject.Any(author =>
            {
                var authorRegexPattern = Regex.Escape(authorPerson)
                    .Replace("%", ".*") // [%]: Matches any string (.*)
                    .Replace("_", "."); // [_]: Matches any single chararcter (.)

                return Regex.IsMatch(author, $"^{authorRegexPattern}$");
            });
        });
    }

    /// | Parameter Name (ITI-18)             | Attribute                        | Opt | Mult |
    /// |-------------------------------------|----------------------------------|-----|------|
    /// | $XDSSubmissionSetContentType (1)(3) | XDSSubmissionSet.contentTypeCode | O   | M    |
    public static IEnumerable<RegistryPackageType> BySubmissionSetContentType(
        this IEnumerable<RegistryPackageType> source, List<string[]>? healthcareFacilityTypeCodes)
    {
        if (healthcareFacilityTypeCodes == null || healthcareFacilityTypeCodes.Count == 0) return source; // Optional field, return everything if not specified
        return source.Where(eo => eo.Classification
            .Where(cf => cf.ClassificationScheme == Constants.Xds.Uuids.SubmissionSet.ContentTypeCode)
            .Select(cf => cf.NodeRepresentation + "^^" + cf.GetSlots(Constants.Xds.SlotNames.CodingScheme).FirstOrDefault()?.GetFirstValue())
            .Any(hcfTypeCode => healthcareFacilityTypeCodes.Any(hcfTypeCodes => hcfTypeCodes.Contains(hcfTypeCode))));
    }
}

public static class FindFolders
{
    /// | Parameter Name (ITI-18) | Attribute           | Opt | Mult |
    /// |-------------------------|---------------------|-----|------|
    /// | $XDSFolderPatientId     | XDSFolder.patientId | R   | -    |
    public static IEnumerable<RegistryPackageType> ByXdsFolderPatientId(
        this IEnumerable<RegistryPackageType> source, string? patientId)
    {
        if (string.IsNullOrWhiteSpace(patientId)) return Enumerable.Empty<RegistryPackageType>();  // Required field, return nothing if not specified

        return source.Where(eo => eo.ExternalIdentifier.Any(ei =>
            ei.IdentificationScheme == Constants.Xds.Uuids.DocumentEntry.PatientId &&
            ei.Value.Contains(patientId)));
    }

}

public static class GetAssociations
{
    /// | Parameter Name (ITI-18) | Attribute        | Opt | Mult |
    /// |-------------------------|------------------|-----|------|
    /// | $uuid                   | None             | R   | M    |
    public static IEnumerable<AssociationType> ByUuid(
        this IEnumerable<AssociationType> source, List<string[]>? uuidList)
    {
        if (uuidList == null || uuidList.Count == 0) return Enumerable.Empty<AssociationType>(); // Required field, return nothing if not specified
        return source.Where(assoc => uuidList.Any(uuids => uuids.Contains(assoc.SourceObject) || uuids.Contains(assoc.TargetObject)));
    }

    /// | Parameter Name (ITI-18)             | Attribute                        | Opt | Mult |
    /// |-------------------------------------|----------------------------------|-----|------|
    /// | $XDSSubmissionSetContentType (1)(3) | XDSSubmissionSet.contentTypeCode | R   | M    |
    public static IEnumerable<AssociationType> ByHomeCommunityId(
        this IEnumerable<AssociationType> source, string? homeCommunityId)
    {
        if (string.IsNullOrWhiteSpace(homeCommunityId)) return source; // Optional field, return everything if not specified
        return source.Where(eo => eo.Home == homeCommunityId);
    }
}

public static class GetFolders
{
    // Either $XDSFolderEntryUUID or $XDSFolderUniqueId shall be specified.
    // This transaction shall return an XDSStoredQueryParamNumber error if both parameters are specified

    /// | Parameter Name (ITI-18)    | Attribute           | Opt | Mult |
    /// |----------------------------|---------------------|-----|------|
    /// | $XDSFolderEntryUUID        | XDSFolder.entryUUID | O   | -    |
    public static IEnumerable<RegistryPackageType> ByXdsFolderEntryUuid(
    this IEnumerable<RegistryPackageType> source, List<string[]>? entryUuidList)
    {
        if (entryUuidList == null || entryUuidList.Count == 0) return source;
        return source.Where(rp => entryUuidList.Any(uuids => uuids.Contains(rp.Id)));
    }

    /// | Parameter Name (ITI-18)   | Attribute           | Opt | Mult |
    /// |---------------------------|---------------------|-----|------|
    /// | $XDSFolderUniqueId        | XDSFolder.entryUUID | O   | -    |
    public static IEnumerable<RegistryPackageType> ByXdsFolderUniqueId(
    this IEnumerable<RegistryPackageType> source, List<string[]>? uniqueIdList)
    {
        if (uniqueIdList == null || uniqueIdList.Count == 0) return source;
        return source.Where(eo => eo.ExternalIdentifier
            .Where(ei => ei.IdentificationScheme == Constants.Xds.Uuids.Folder.UniqueId)
            .Any(extId => uniqueIdList.Any(sourceIdArray => sourceIdArray.Contains(extId.Value))));
    }
}

public static class GetFolderAndContents
{
    /// | Parameter Name (ITI-18)    | Attribute           | Opt | Mult |
    /// |----------------------------|---------------------|-----|------|
    /// | $XDSFolderEntryUUID        | XDSFolder.entryUUID | O   | -    |
    public static IEnumerable<IdentifiableType> ByXdsFolderEntryUuid(
        this IEnumerable<IdentifiableType> source, string? entryUuid)
    {
        if (entryUuid == null) return source;

        var folders = source.GetFolder(entryUuid);

        var contentRelatedToFolder = source.GetContentRelatingToFolders(folders);

        return contentRelatedToFolder;
    }

    /// | Parameter Name (ITI-18)   | Attribute           | Opt | Mult |
    /// |---------------------------|---------------------|-----|------|
    /// | $XDSFolderUniqueId        | XDSFolder.entryUUID | O   | -    |
    public static IEnumerable<IdentifiableType> ByXdsFolderUniqueId(
        this IEnumerable<IdentifiableType> source, string? uniqueId)
    {
        if (uniqueId == null) return source;
        return source.OfType<RegistryPackageType>().Where(eo => eo.ExternalIdentifier
            .Where(ei => ei.IdentificationScheme == Constants.Xds.Uuids.Folder.UniqueId)
            .Any(extId => uniqueId == extId.Value));
    }

    /// | Parameter Name (ITI-18)     | Attribute                   | Opt | Mult |
    /// |-----------------------------|-----------------------------|-----|------|
    /// | $XDSDocumentEntryFormatCode | XDSDocumentEntry.formatCode | O   | M    |
    public static IEnumerable<IdentifiableType> ByXdsDocumentEntryFormatCode(
        this IEnumerable<IdentifiableType> source, List<string[]>? formatCodes)
    {
        if (formatCodes == null || formatCodes.Count == 0) return source; // Optional field, return everything if not specified

        return source;
    }

    /// | Parameter Name (ITI-18)                  | Attribute                            | Opt | Mult |
    /// |------------------------------------------|--------------------------------------|-----|------|
    /// | $XDSDocumentEntryConfidentialityCode (3) | XDSDocumentEntry.confidentialityCode | O   | M    |
    public static IEnumerable<RegistryPackageType> ByXdsDocumentEntryConfidentialityCode(
        this IEnumerable<RegistryPackageType> source, List<string[]>? confidentialityGroups)
    {
        if (confidentialityGroups == null || confidentialityGroups.Count == 0) return source; // Optional field, return everything if not specified

        return source;
    }

    public static IEnumerable<RegistryPackageType> ByXdsDocumentEntryType(
        this IEnumerable<RegistryPackageType> source, List<string[]>? typeCodes)
    {
        // https://profiles.ihe.net/ITI/TF/Volume2/ITI-18.html#3.18.4.1.2.3.6.2
        // If no value is specified for DocumentEntryType, the value requesting only Stable Document Entries shall be assumed
        if (typeCodes == null || typeCodes.Count == 0) return source.Where(eo => typeCodes.Any(tcArr => tcArr.Any(tc => tc.NoUrn() == Constants.Xds.Uuids.DocumentEntry.StableDocumentEntries.NoUrn()))); ;
        return source.Where(eo => typeCodes.Any(tcArr => tcArr.Any(tc => tc.NoUrn() == eo.ObjectType.NoUrn())));
    }
}

public static class Commons
{
    /// <summary>
    /// Returns:
    /// Folder identified
    /// DocumentEntries linked to the Folder by HasMember Associations(DocumentEntries shall pass the above rules)
    /// The HasMember Associations identified in the previous rule
    /// </summary>
    public static IEnumerable<IdentifiableType> GetContentRelatingToFolders(
        this IEnumerable<IdentifiableType> source, IEnumerable<IdentifiableType> folders)
    {

        var folderAssociations = source.OfType<AssociationType>()
            .Where(aso => folders.Any(fol => aso.TargetObject == fol.Id)).ToList();

        var associationsBySource = source.OfType<AssociationType>()
            .GroupBy(a => a.SourceObject)
            .ToDictionary(g => g.Key, g => g.ToList());

        var allRelatedAssociations = folderAssociations
            .SelectMany(folderAssoc => associationsBySource.TryGetValue(folderAssoc.SourceObject, out var related)
                ? related
                : Enumerable.Empty<AssociationType>())
            .ToList();

        // HasMember Associations for DocumentEntries linked to the Folder
        var allTargetObjects = allRelatedAssociations
            .Where(asoc => asoc.AssociationTypeData == Constants.Xds.AssociationType.HasMember)
            .Select(a => a.TargetObject).Distinct().ToList();

        var documentEntries = source.Where(ro => allTargetObjects.Contains(ro.Id)).ToList();

        return documentEntries.Concat(folderAssociations);
    }


    public static IEnumerable<IdentifiableType> GetFolder(this IEnumerable<IdentifiableType> source, string entryUuid)
    {
        return source.OfType<RegistryPackageType>().Where(rp =>
            rp.Classification.Any(cl => cl.ClassificationNode == Constants.Xds.Uuids.Folder.FolderClassificationNode && rp.Id == entryUuid));
    }

    public static string[] GetValues(this SlotType[] slotTypes, bool codeMultipleValues = true)
    {
        if (slotTypes == null || slotTypes.Length == 0)
        {
            return Array.Empty<string>();
        }

        return slotTypes
            .SelectMany(slot => slot.GetValues(codeMultipleValues) ?? [])
            .ToArray();
    }

    public static List<string[]> GetValuesGrouped(this SlotType[] slotTypes, bool codeMultipleValues = true)
    {
        if (slotTypes == null || slotTypes.Length == 0)
        {
            return new List<string[]>();
        }

        return slotTypes
            .Select(slot => slot.GetValues(codeMultipleValues) ?? Array.Empty<string>())
            .Where(values => values.Length > 0)
            .ToList();
    }

    public static IdentifiableType GetById(this IEnumerable<IdentifiableType> identifiableTypes, string id)
    {
        return identifiableTypes.FirstOrDefault(ro => ro.Id == id);
    }
}
