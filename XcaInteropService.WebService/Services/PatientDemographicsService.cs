using XcaInteropService.Commons.Models.Hl7.V3;
using XcaInteropService.Commons.Services;
using XcaInteropService.Source.Services;

namespace XcaInteropService.WebService.Services;

public class PatientDemographicsService
{
    private readonly ILogger<PatientDemographicsService> _logger;
    private readonly PatientDemographicsWrapper _patientDemographicsWrapper;

    public PatientDemographicsService(ILogger<PatientDemographicsService> logger, PatientDemographicsWrapper patientDemographicsWrapper)
    {
        _logger = logger;
        _patientDemographicsWrapper = patientDemographicsWrapper;
    }

    public MCCI_IN000002UV01? UploadPatientIdentity(PRPA_IN201301UV02? addPatientRequest)
    {
        if (addPatientRequest == null) return null;

        var patientDto = PatientIdentityTransformerService.TransformAddPatientToPatientDto(addPatientRequest);

        _patientDemographicsWrapper.UpdatePatientDemographics(patientDto);

        return new MCCI_IN000002UV01()
        {
            Acknowledgement = new()
            {
                TargetMessage = [addPatientRequest.Id]
            },
            Sender = new()
            {
                Device = new()
                {
                    Id = addPatientRequest.Receiver?.Device.Id,
                    AsAgent = new()
                    {
                        RepresentedOrganization = new()
                        {
                            Id = addPatientRequest.Receiver?.Device.Id
                        }
                    }
                }
            },
            Receiver = new()
            {
                Device = new()
                {
                    Id = addPatientRequest.Sender?.Device?.Id,
                    AsAgent = new()
                    {
                        RepresentedOrganization = new()
                        {
                            Id = addPatientRequest.Sender?.Device?.Id
                        }
                    }
                }
            }
        };
    }
}