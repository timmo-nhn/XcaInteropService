using XcaInteropService.Commons.Models.Soap;
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

    public SoapEnvelope UploadPatientIdentity(SoapEnvelope soapEnvelope)
    {
        var responseEnvelope = new SoapEnvelope();
        var addPatientRequest = soapEnvelope.Body.PRPA_IN201301UV02;

        var patientDto = PatientIdentityTransformerService.TransformAddPatientToPatientDto(addPatientRequest);

        _patientDemographicsWrapper.UpdateRegistry([patientDto]);


        return responseEnvelope;
    }
}