using XcaInteropService.Commons.Models.Soap;
using XcaInteropService.Commons.Models.Soap.XdsTypes;
using XcaInteropService.Source.Services;

namespace XcaInteropService.WebService.Services;

public class ValueSetRepositoryService
{
    private readonly ILogger<ValueSetRepositoryService> _logger;
    private readonly ValueSetRepositoryWrapper _valueSetRepositoryWrapper;

    private List<ValueSetType> _valueSets;

    public ValueSetRepositoryService(ILogger<ValueSetRepositoryService> logger, ValueSetRepositoryWrapper valueSetRepositoryWrapper)
    {
        _logger = logger;
        _valueSetRepositoryWrapper = valueSetRepositoryWrapper;
        _valueSets = _valueSetRepositoryWrapper.ReadAllValueSets();
    }

    public async Task<SoapEnvelope> RetrieveValueSet(SoapEnvelope soapEnvelope)
    {
        var responseEnvelope = new SoapEnvelope();

        var valueSetRequest = soapEnvelope.Body.RetrieveValueSetRequest;

        var valueSet = valueSetRequest?.ValueSet;
        var responseValueSet = _valueSets.FirstOrDefault(vs => vs.Id == valueSet?.Id);

        responseEnvelope.Header = new()
        {
            Action = soapEnvelope.GetCorrespondingResponseAction()
        };

        responseEnvelope.Body = new()
        {
            RetrieveValueSetResponse = new()
            {
                ValueSet = responseValueSet
            }
        };

        return responseEnvelope;
    }

    public bool UploadSingleConcept(string oid, string language, string code, string codeSystem, string displayName)
    {
        var concept = new ConceptType()
        {
            Code = code,
            CodeSystemName = codeSystem,
            DisplayName = displayName
        };

        var valueSet = _valueSets.FirstOrDefault(vs => vs.Id == oid);

        if (valueSet == null)
        {
            valueSet = new()
            {
                Id = oid,
            };
        }

        valueSet.ConceptList.lang = language;
        valueSet.ConceptList.Concept = [.. valueSet.ConceptList.Concept ?? [], concept];

        _valueSetRepositoryWrapper.WriteValueSet(oid, valueSet);

        _valueSets = _valueSetRepositoryWrapper.ReadAllValueSets();

        return true;
    }

    public bool UploadConceptList(string oid, string lang, List<ConceptType> conceptList)
    {
        var valueSet = _valueSets.FirstOrDefault(vs => vs.Id == oid);

        if (valueSet == null)
        {
            valueSet = new()
            {
                Id = oid,
                ConceptList = new()
                {
                    lang = lang,
                    Concept = [.. conceptList]
                }
            };
        }

        _valueSetRepositoryWrapper.WriteValueSet(oid, valueSet);

        _valueSets = _valueSetRepositoryWrapper.ReadAllValueSets();
        
        return true;
    }
}
