using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Extensions;
using XcaInteropService.Commons.Models.Soap.XdsTypes;

namespace XcaInteropService.Commons.Models.Custom;

public static class RegistryStoredQueryParameters
{
    public static FindDocuments GetFindDocumentsParameters(AdhocQueryType adhocQuery)
    {
        return new FindDocuments()
        {
            XdsDocumentEntryPatientId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.PatientId).FirstOrDefault()?.GetFirstValue(),
            XdsDocumentEntryStatus = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.Status)?.GetValuesGrouped(),
            XdsDocumentEntryClassCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.ClassCode).GetValuesGrouped(),
            XdsDocumentEntryTypeCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.TypeCode).GetValuesGrouped(),
            XdsDocumentEntryPracticeSettingCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.PracticeSettingCode).GetValuesGrouped(),
            XdsDocumentEntryCreationTimeFrom = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.CreationTimeFrom).FirstOrDefault()?.GetFirstValue(),
            XdsDocumentEntryCreationTimeTo = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.CreationTimeTo).FirstOrDefault()?.GetFirstValue(),
            XdsDocumentEntryServiceStartTimeFrom = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.ServiceStartTimeFrom).FirstOrDefault()?.GetFirstValue(),
            XdsDocumentEntryServiceStartTimeTo = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.ServiceStartTimeTo).FirstOrDefault()?.GetFirstValue(),
            XdsDocumentEntryServiceStoptimeFrom = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.ServiceStopTimeFrom).FirstOrDefault()?.GetFirstValue(),
            XdsDocumentEntryServiceStoptimeTo = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.ServiceStopTimeTo).FirstOrDefault()?.GetFirstValue(),
            XdsDocumentEntryHealthcareFacilityTypeCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.HealthcareFacilityTypeCode).GetValuesGrouped(),
            XdsDocumentEntryEventCodeList = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.EventCodeList).GetValuesGrouped(),
            XdsDocumentEntryConfidentialityCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.ConfidentialityCode).GetValuesGrouped(),
            XdsDocumentEntryAuthorPerson = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.AuthorPerson).GetValuesGrouped(),
            XdsDocumentEntryFormatCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.FormatCode).GetValuesGrouped(),
            XdsDocumentEntryType = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindDocuments.Type).GetValuesGrouped(),
        };
    }

    public static FindSubmissionSets GetFindSubmissionSetsParameters(AdhocQueryType adhocQuery)
    {
        return new FindSubmissionSets()
        {
            XdsSubmissionSetPatientId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindSubmissionSets.PatientId).FirstOrDefault()?.GetFirstValue(),
            XdsSubmissionSetSourceId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindSubmissionSets.SourceId).GetValuesGrouped(),
            XdsSubmissionSetSubmissionTimeFrom = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindSubmissionSets.SubmissionTimeFrom).FirstOrDefault()?.GetFirstValue(),
            XdsSubmissionSetSubmissionTimeTo = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindSubmissionSets.SubmissionTimeTo).FirstOrDefault()?.GetFirstValue(),
            XdsSubmissionSetAuthorPerson = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindSubmissionSets.AuthorPerson).FirstOrDefault()?.GetFirstValue(),
            XdsSubmissionSetContentType = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindSubmissionSets.ContentType).GetValuesGrouped(),
            XdsSubmissionSetStatus = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindSubmissionSets.Status).GetValuesGrouped(),
        };
    }

    public static FindFolders GetFindFoldersParameters(AdhocQueryType adhocQuery)
    {
        return new FindFolders()
        {

            XdsFolderPatientId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindFoldes.XdsFolderPatientId).FirstOrDefault()?.GetFirstValue(),
            XdsFolderLastUpdateTimeFrom = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindFoldes.XdsFolderLastUpdateTimeFrom).FirstOrDefault()?.GetFirstValue(),
            XdsFolderLastUpdateTimeTo = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindFoldes.XdsFolderLastUpdateTimeTo).FirstOrDefault()?.GetFirstValue(),
            XdsFolderCodeList = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindFoldes.XdsFolderCodeList).GetValuesGrouped(),
            XdsFolderStatus = adhocQuery.GetSlots(Constants.Xds.QueryParameters.FindFoldes.XdsFolderStatus).GetValuesGrouped(),
        };
    }

    public static GetAll GetAllParameters(AdhocQueryType adhocQuery)
    {
        return new GetAll()
        {
            PatientId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetAll.PatientId).FirstOrDefault()?.GetFirstValue(),
            XdsDocumentEntryStatus = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetAll.DocumentEntryStatus).GetValuesGrouped(),
            XdsSubmissionSetStatus = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetAll.SubmissionSetStatus).GetValuesGrouped(),
            XdsFolderStatus = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetAll.FolderStatus).GetValuesGrouped(),
            XdsDocumentEntryFormatCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetAll.DocumentEntryFormatCode).GetValuesGrouped(),
            XdsDocumentEntryConfidentialityCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetAll.DocumentEntryConfidentialityCode).GetValuesGrouped(),
            XdsDocumentEntryType = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetAll.DocumentEntryType).GetValuesGrouped(),
        };
    }

    public static GetDocuments GetDocumentsParameters(AdhocQueryType adhocQuery)
    {
        return new GetDocuments()
        {
            XdsDocumentEntryUuid = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetDocuments.XdsDocumentEntryUuid).GetValuesGrouped(),
            XdsDocumentEntryUniqueId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetDocuments.XdsDocumentEntryUniqueId).GetValuesGrouped(),
            HomeCommunityId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.Associations.HomeCommunityId).FirstOrDefault()?.GetFirstValue(),
        };
    }

    public static GetAssociations GetAssociationsParameters(AdhocQueryType adhocQuery)
    {
        return new GetAssociations()
        {
            Uuid = adhocQuery.GetSlots(Constants.Xds.QueryParameters.Associations.Uuid).GetValuesGrouped(),
            HomeCommunityId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.Associations.HomeCommunityId).FirstOrDefault()?.GetFirstValue(),
        };
    }

    public static GetFolders GetFoldersParameters(AdhocQueryType adhocQuery)
    {
        return new GetFolders()
        {
            XdsFolderEntryUuid = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetFolders.XdsFolderEntryUuid).GetValuesGrouped(),
            XdsFolderUniqueId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetFolders.XdsFolderUniqueId).GetValuesGrouped()
        };
    }

    public static GetFolderAndContents GetFolderAndContentsParameters(AdhocQueryType adhocQuery)
    {
        return new GetFolderAndContents()
        {
            XdsFolderEntryUuid = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetFolderAndContents.XdsFolderEntryUuid).FirstOrDefault()?.GetFirstValue(),
            XdsFolderUniqueId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetFolderAndContents.XdsFolderUniqueId).FirstOrDefault()?.GetFirstValue(),
            XdsDocumentEntryFormatCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetFolderAndContents.XdsDocumentEntryFormatCode).GetValuesGrouped(),
            XdsDocumentEntryConfidentialityCode = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetFolderAndContents.XdsDocumentEntryConfidentialityCode).GetValuesGrouped(),
            XdsDocumentEntryType = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetFolderAndContents.XdsDocumentEntryType).GetValuesGrouped(),
            homeCommunityId = adhocQuery.GetSlots(Constants.Xds.QueryParameters.GetFolderAndContents.homeCommunityId).FirstOrDefault()?.GetFirstValue(),
        };
    }
}


// https://profiles.ihe.net/ITI/TF/Volume2/ITI-18.html#3.18.4.1.2.3.7
public class FindDocuments
{
    public string? XdsDocumentEntryPatientId { get; set; }
    public List<string[]>? XdsDocumentEntryClassCode { get; set; }
    public List<string[]>? XdsDocumentEntryTypeCode { get; set; }
    public List<string[]>? XdsDocumentEntryPracticeSettingCode { get; set; }
    public string? XdsDocumentEntryCreationTimeFrom { get; set; }
    public string? XdsDocumentEntryCreationTimeTo { get; set; }
    public string? XdsDocumentEntryServiceStartTimeFrom { get; set; }
    public string? XdsDocumentEntryServiceStartTimeTo { get; set; }
    public string? XdsDocumentEntryServiceStoptimeFrom { get; set; }
    public string? XdsDocumentEntryServiceStoptimeTo { get; set; }
    public List<string[]>? XdsDocumentEntryHealthcareFacilityTypeCode { get; set; }
    public List<string[]>? XdsDocumentEntryEventCodeList { get; set; }
    public List<string[]>? XdsDocumentEntryConfidentialityCode { get; set; }
    public List<string[]>? XdsDocumentEntryAuthorPerson { get; set; }
    public List<string[]>? XdsDocumentEntryFormatCode { get; set; }
    public List<string[]>? XdsDocumentEntryStatus { get; set; }
    public List<string[]>? XdsDocumentEntryType { get; set; }
}

public class FindSubmissionSets
{
    public string? XdsSubmissionSetPatientId { get; set; }
    public List<string[]> XdsSubmissionSetSourceId { get; set; }
    public string? XdsSubmissionSetSubmissionTimeFrom { get; set; }
    public string? XdsSubmissionSetSubmissionTimeTo { get; set; }
    public string? XdsSubmissionSetAuthorPerson { get; set; }
    public List<string[]> XdsSubmissionSetContentType { get; set; }
    public List<string[]> XdsSubmissionSetStatus { get; set; }
}

public class FindFolders
{
    public string? XdsFolderPatientId { get; set; }
    public string? XdsFolderLastUpdateTimeFrom { get; set; }
    public string? XdsFolderLastUpdateTimeTo { get; set; }
    public List<string[]>? XdsFolderCodeList { get; set; }
    public List<string[]>? XdsFolderStatus { get; set; }
}

public class GetAll
{
    public string? PatientId { get; set; }
    public List<string[]> XdsDocumentEntryStatus { get; set; }
    public List<string[]> XdsSubmissionSetStatus { get; set; }
    public List<string[]> XdsFolderStatus { get; set; }
    public List<string[]> XdsDocumentEntryFormatCode { get; set; }
    public List<string[]> XdsDocumentEntryConfidentialityCode { get; set; }
    public List<string[]> XdsDocumentEntryType { get; set; }
}

public class GetDocuments
{
    public List<string[]> XdsDocumentEntryUuid { get; set; }
    public List<string[]> XdsDocumentEntryUniqueId { get; set; }
    public string? HomeCommunityId { get; set; }
}


public class GetAssociations
{
    public List<string[]> Uuid { get; set; }
    public string? HomeCommunityId { get; set; }

}

public class GetFolders
{
    public List<string[]>? XdsFolderEntryUuid { get; set; }
    public List<string[]>? XdsFolderUniqueId { get; set; }
}

public class GetFolderAndContents
{
    public string? XdsFolderEntryUuid { get; set; }
    public string? XdsFolderUniqueId { get; set; }
    public List<string[]>? XdsDocumentEntryFormatCode { get; set; }
    public List<string[]>? XdsDocumentEntryConfidentialityCode { get; set; }
    public List<string[]>? XdsDocumentEntryType { get; set; }
    public string? homeCommunityId { get; set; }
}