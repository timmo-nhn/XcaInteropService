using XcaInteropService.Commons.Models.Custom.PatientIdentityDtos;
using XcaInteropService.Commons.Models.Custom.RegistryDtos;
using XcaInteropService.Source.Models.DatabaseDtos;

namespace XcaInteropService.Source.Services;

public static class DatabaseMapper
{
    public static PatientIdentityDto? MapFromDatabaseEntityToDto(DbPatientIdentityDto dbPatientIdentity)
    {
        return MapFromDatabaseEntityToDto([dbPatientIdentity]).FirstOrDefault();
    }

    public static List<PatientIdentityDto> MapFromDatabaseEntityToDto(List<DbPatientIdentityDto> dbPatientIdentityList)
    {
        var patientIdentities = new List<PatientIdentityDto>();

        foreach (var patientIdentity in dbPatientIdentityList ?? [])
        {

        }

        return patientIdentities;
    }

    public static DbPatientIdentityDto? MapFromDtoToDatabaseEntity(PatientIdentityDto registryObjectDtos)
    {
        return MapFromDtoToDatabaseEntity([registryObjectDtos]).FirstOrDefault();
    }

    public static List<DbPatientIdentityDto> MapFromDtoToDatabaseEntity(List<PatientIdentityDto> patientIdentityDtos)
    {
        var dbPatientIdentities = new List<DbPatientIdentityDto>();

        foreach (var patientIdentity in patientIdentityDtos ?? [])
        {

        }

        return dbPatientIdentities;
    }
}