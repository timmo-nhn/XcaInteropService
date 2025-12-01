using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.ClinicalDocument.Types;
using XcaInteropService.Commons.Models.Custom.PatientIdentityDtos;
using XcaInteropService.Commons.Models.Hl7.CommunicationFunctions;
using XcaInteropService.Commons.Models.Hl7.DataType;
using XcaInteropService.Commons.Models.Hl7.V3;

namespace XcaInteropService.Commons.Services;

public static class PatientIdentityTransformerService
{
    public static PatientIdentityDto? TransformAddPatientToPatientDto(PRPA_IN201301UV02? addPatientRequest)
    {
        var patientIdentity = new PatientIdentityDto();

        var subject = addPatientRequest?.ControlActProcess?.Subject?.RegistrationEvent?.Subject1;
        if (subject == null) return null;

        patientIdentity.Id = Guid.NewGuid().ToString();
        patientIdentity.Name = GetXpnPatientNameFromAddPatientPatient(subject.Patient?.Patient);

        var identifiers = GetCxPatientIdFromPatient(subject.Patient);
        patientIdentity.Identifier = identifiers?.FirstOrDefault();
        patientIdentity.BirthTime = subject.Patient?.Patient?.BirthTime?.EffectiveTime.Date;
        patientIdentity.DeceasedTime = subject.Patient?.Patient?.sdtcDeceasedTime?.EffectiveTime.Date;
        patientIdentity.GenderCode = GetCeGenderFromPatient(subject?.Patient?.Patient);

        patientIdentity.AlternateIdentifiers ??= new();
        patientIdentity.AlternateIdentifiers.AddRange(GetAlternateIdentifiersFromPatient(subject?.Patient?.Patient) ?? []);
        patientIdentity.AlternateIdentifiers.AddRange(identifiers?.Skip(1) ?? []);

        return patientIdentity;
    }

    private static List<CX>? GetAlternateIdentifiersFromPatient(CFPatientPerson? patient)
    {
        var identifiers = new List<CX>();

        foreach (var alternateId in patient?.asOtherIds ?? [])
        {
            var id = alternateId.Id?.FirstOrDefault();
            identifiers.Add(new CX()
            {
                IdNumber = id?.Extension,
                AssigningAuthority = new HD()
                {
                    UniversalId = id?.Root,
                    UniversalIdType = alternateId?.ScopingOrganization?.Id?.FirstOrDefault()?.Root ?? Constants.Hl7.UniversalIdType.Iso,
                }
            });
        }

        return identifiers;
    }

    private static CE? GetCeGenderFromPatient(CFPatientPerson? patient)
    {
        return patient?.AdministrativeGenderCode;
    }

    private static List<CX>? GetCxPatientIdFromPatient(CFPatient? patient)
    {
        return patient?.Id?.Select(pid => new CX()
        {
            IdNumber = pid.Extension,
            AssigningAuthority = new HD()
            {
                UniversalId = pid.Root
            }
        }).ToList();
    }

    private static XPN? GetXpnPatientNameFromAddPatientPatient(CFPatientPerson? patient)
    {
        var name = patient?.Name?.FirstOrDefault();
        if (name == null) return null;

        return new XPN()
        {
            GivenName = string.Join(" ", name.Given?.Select(fam => fam.Value) ?? []),
            FamilyName = string.Join(" ", name.Family?.Select(giv => giv.Value) ?? [])
        };
    }
}