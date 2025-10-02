using XcaInteropService.Commons.Models.Custom.RestfulRegistry;
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

    public SoapEnvelope RetrieveValueSet(SoapEnvelope soapEnvelope)
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

    public List<ValueSetType> GetValueSetList()
    {
        return _valueSets;
    }

    public RestfulApiResponse UploadSingleConcept(string oid, string language, string code, string codeSystem, string displayName)
    {
        var response = new RestfulApiResponse();

        var concept = new ConceptType()
        {
            Code = code,
            CodeSystemName = codeSystem,
            DisplayName = displayName
        };

        var valueSet = _valueSets.FirstOrDefault(vs => vs.Id == oid && vs.lang == language);

        if (valueSet == null || valueSet.lang != language)
        {
            _logger.LogInformation($"Adding new ValueSet {oid} - {language}");
            response.SetMessage($"Added new ValueSet {oid} - {language}");

            valueSet = new()
            {
                Id = oid,
                lang = language
            };
        }
        else
        {
            _logger.LogInformation($"Adding value to existing ValueSet {oid} - {language}");
            response.SetMessage($"Added value to existing ValueSet {oid} - {language}");
        }

        valueSet.ConceptList ??= new();
        valueSet.ConceptList.lang ??= language;
        valueSet.ConceptList.Concept = [.. valueSet.ConceptList.Concept ?? [], concept];

        _valueSetRepositoryWrapper.WriteValueSet(oid, language, valueSet);

        _valueSets = _valueSetRepositoryWrapper.ReadAllValueSets();

        return response;
    }

    public bool UploadConceptList(string oid, string lang, ValueSetType valueSet)
    {
        return UploadConceptList(oid, lang, valueSet.ConceptList.Concept.ToList());
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

        _valueSetRepositoryWrapper.WriteValueSet(oid, lang, valueSet);

        _valueSets = _valueSetRepositoryWrapper.ReadAllValueSets();

        return true;
    }

    public bool DeleteConcept(string oid, string conceptId)
    {
        var valueSet = _valueSets.FirstOrDefault(v => v.Id == oid);
        if (valueSet == null) return false;

        var concepts = _valueSets.Select(vs => vs.ConceptList.Concept).Where(c => c.Any(con => con.Code == conceptId || con.DisplayName == conceptId));

        _valueSets = _valueSetRepositoryWrapper.ReadAllValueSets();
        return true;
    }
}
