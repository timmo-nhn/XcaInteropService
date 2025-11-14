using System.Reflection.Metadata.Ecma335;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;
using XcaInteropService.Commons.Models.Custom.PatientIdentityDtos;
using XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;
using XcaInteropService.Commons.Models.Hl7.DataType;
using XcaInteropService.Commons.Models.Hl7.V3;

namespace XcaInteropService.Commons.Services;

public static class PatientIdentityTransformerService
{
    public static PatientIdentityDto? TransformAddPatientToPatientDto(PRPA_IN201301UV02_AddNewPatient? addPatientRequest)
    {
        var patientIdentity = new PatientIdentityDto();

        var patient = addPatientRequest?.ControlActProcess?.Subject?.RegistrationEvent?.Subject1?.Patient?.Patient;
        if (patient == null) return null;
        
        patientIdentity.Id = Guid.NewGuid().ToString();
        patientIdentity.Name = GetXpnPatientNameFromAddPatientPatient(patient);
        patientIdentity.Identifier = GetCxPatientIdFromPatient(patient);
        patientIdentity.BirthTime = patient.BirthTime?.EffectiveTime.Date;
        patientIdentity.DeceasedTime = patient.sdtcDeceasedTime?.EffectiveTime.Date;
        patientIdentity.GenderCode = GetCeGenderFromPatient(patient);
        patientIdentity.AlternateIdentifiers = GetAlternateIdentifiersFromPatient(patient);

        return patientIdentity;
    }

    private static List<CX>? GetAlternateIdentifiersFromPatient(CFPatientPerson patient)
    {
        var identifiers = new List<CX>();

        foreach (var alternateId in patient.asOtherIds)
        {
            var id = alternateId.Id?.FirstOrDefault();
            identifiers.Add(new CX()
            {
                IdNumber = id.Extension,
                AssigningAuthority = new HD()
                {
                    UniversalId = id.Root,
                    UniversalIdType = alternateId.ScopingOrganization?.Id?.FirstOrDefault()?.Root ?? Constants.Hl7.UniversalIdType.Iso,
                }
            });
        }

        return identifiers;
    }

    private static CE? GetCeGenderFromPatient(CFPatientPerson patient)
    {
        return patient.AdministrativeGenderCode;
    }

    private static CX? GetCxPatientIdFromPatient(CFPatientPerson patient)
    {
        return new CX()
        {
            IdNumber = patient.Id?.Extension,
            AssigningAuthority = new HD()
            {
                UniversalId = patient.Id?.Root,
                UniversalIdType = Constants.Hl7.UniversalIdType.Iso
            }
        };
    }

    private static XPN? GetXpnPatientNameFromAddPatientPatient(CFPatientPerson? patient)
    {
        var name = patient?.Name?.FirstOrDefault();
        if (name == null) return null;

        return new XPN()
        {
            GivenName = string.Join(" ", name.Family ?? []),
            FamilyName = string.Join(" ", name.Given ?? [])
        };
    }
}