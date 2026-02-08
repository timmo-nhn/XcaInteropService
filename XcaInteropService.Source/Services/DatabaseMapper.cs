using XcaInteropService.Commons.Models.ClinicalDocument.Types;
using XcaInteropService.Commons.Models.Custom.PatientIdentityDtos;
using XcaInteropService.Commons.Models.Hl7.DataType;
using XcaInteropService.Source.Models.DatabaseDtos;
using XcaInteropService.Source.Models.DatabaseDtos.Types;

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

        foreach (var dbPatientIdentity in dbPatientIdentityList ?? [])
        {
            if (dbPatientIdentity == null) continue;

            patientIdentities.Add(new PatientIdentityDto()
            {
                BirthTime = dbPatientIdentity.BirthTime,
                DeceasedTime = dbPatientIdentity.DeceasedTime,
                GenderCode = new CE()
                {
                    Code = dbPatientIdentity.GenderCode,
                    CodeSystem = dbPatientIdentity.GenderCodeSystem,
                    DisplayName = dbPatientIdentity.GenderDisplayName
                },
                Id = dbPatientIdentity.Id,
                Identifier = new CX()
                {
                    IdNumber = dbPatientIdentity.IdentifierCode,
                    AssigningAuthority = new HD()
                    {
                        UniversalId = dbPatientIdentity.IdentifierCodeSystem,
                        UniversalIdType = dbPatientIdentity.IdentifierCodeSystemAuthority,
                    },
                },
                Name = new XPN()
                {
                    FamilyName = dbPatientIdentity.NameLastName,
                    GivenName = dbPatientIdentity.NameFirstName
                },
                AlternateIdentifiers = dbPatientIdentity.AlternatePatientIdentifiers?.Select(altIds => new CX()
                {
                    IdNumber = altIds.Code,
                    AssigningAuthority = new HD()
                    {
                        NamespaceId = altIds.CodeSystemAuthority,
                        UniversalId = altIds.CodeSystem
                    }
                }).ToList()
            });
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

        foreach (var patientIdentityDto in patientIdentityDtos ?? [])
        {
            if (patientIdentityDto == null) continue;

            dbPatientIdentities.Add(new DbPatientIdentityDto()
            {
                BirthTime = patientIdentityDto.BirthTime,
                DeceasedTime = patientIdentityDto.DeceasedTime,
                GenderCode = patientIdentityDto.GenderCode?.Code,
                GenderCodeSystem = patientIdentityDto.GenderCode?.CodeSystem,
                GenderDisplayName = patientIdentityDto.GenderCode?.DisplayName,
                Id = patientIdentityDto.Id,
                IdentifierCode = patientIdentityDto.Identifier?.IdNumber,
                IdentifierCodeSystemAuthority = patientIdentityDto.Identifier?.AssigningAuthority?.NamespaceId,
                IdentifierCodeSystem = patientIdentityDto.Identifier?.AssigningAuthority?.UniversalId,
                NameFirstName = patientIdentityDto.Name?.GivenName,
                NameLastName = patientIdentityDto.Name?.FamilyName,
                AlternatePatientIdentifiers = patientIdentityDto.AlternateIdentifiers?.Select(altIds => new DbCodedIdentifier()
                {
                    Code = altIds.IdNumber,
                    CodeSystem = altIds.AssigningAuthority?.UniversalId,
                    CodeSystemAuthority = altIds.AssigningAuthority?.NamespaceId,
                }).ToList()
            });
        }

        return dbPatientIdentities;
    }
}