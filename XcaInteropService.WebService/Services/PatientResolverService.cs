using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Commons.Models.Custom.PatientIdentityDtos;
using XcaInteropService.Commons.Models.Hl7.DataType;
using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.WebService.Services;

public class PatientResolverService
{
    private readonly ApplicationConfig _appConfig;


    public PatientResolverService(ApplicationConfig appConfig)
    {
        _appConfig = appConfig;
    }

    public void ResolvePatientForTargetCommunity(DomainConfig targetCommunity, IEnumerable<PatientIdentityDto?> patientDemographics)
    {
        var matchingPatients = patientDemographics.Where(pdmo => targetCommunity.HomeCommunityId == pdmo?.Identifier?.AssigningAuthority?.UniversalId).Select(pid => new HD() { });
        throw new NotImplementedException();
    }

    public List<HD> GetPatientAssigningAuthorities(DomainConfigMap domainConfigMap, SoapEnvelope soapEnvelope)
    {
        var hdList = new List<HD>();

        var adhocQueryPatientSlot = soapEnvelope.Body?.AdhocQueryRequest?.AdhocQuery?.GetFirstSlot(Constants.Xds.QueryParameters.FindDocuments.PatientId)?.GetFirstValue();
        var patientIdentifier = Hl7Object.Parse<CX>(adhocQueryPatientSlot);

        if (patientIdentifier?.AssigningAuthority != null)
        {
            patientIdentifier.AssigningAuthority.UniversalIdType = Constants.Xds.Pix.IdentifierTypes.SSN;
            hdList.Add(patientIdentifier.AssigningAuthority);
        }

        return hdList;
    }
}