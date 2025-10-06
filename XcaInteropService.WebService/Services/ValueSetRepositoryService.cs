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
        var responseValueSet = _valueSets.FirstOrDefault(vs => vs.Id == valueSet.Id && vs.Language == valueSet.Language);

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

    public SoapEnvelope RetrieveMultipleValueSets(SoapEnvelope soapEnvelope)
    {
        throw new NotImplementedException();
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

        var valueSet = _valueSets.FirstOrDefault(vs => vs.Id == oid && vs.Language == language);

        if (valueSet == null || valueSet.Language != language)
        {
            _logger.LogInformation($"Adding new ValueSet {oid} - {language}");
            response.SetMessage($"Added new ValueSet {oid} - {language}");

            valueSet = new()
            {
                Id = oid,
                Language = language
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

    public RestfulApiResponse UploadConceptList(string oid, string lang, ValueSetType valueSet)
    {
        return UploadConceptList(oid, lang, valueSet.ConceptList.Concept.ToList());
    }

    public RestfulApiResponse UploadConceptList(string oid, string language, List<ConceptType> conceptList)
    {
        var response = new RestfulApiResponse();

        // Find existing valueset based on OID and language
        var valueSet = _valueSets.FirstOrDefault(vs => vs.Id == oid && vs.Language == language);

        if (valueSet == null)
        {
            var message = $"Adding {conceptList.Count} values to new ValueSet: {oid} - {language}";
            _logger.LogInformation(message);
            response.SetMessage(message);

            valueSet = new()
            {
                Id = oid,
                Language = language
            };
        }
        else
        {
            var message = $"Added {conceptList.Count} value(s) to ValueSet: {oid} - {language}";
            _logger.LogInformation(message);
            response.SetMessage(message);
        }

        valueSet.ConceptList ??= new();
        valueSet.ConceptList.Concept = [.. valueSet.ConceptList.Concept ?? [], .. conceptList];

        _valueSetRepositoryWrapper.WriteValueSet(oid, language, valueSet);


        _valueSets = _valueSetRepositoryWrapper.ReadAllValueSets();

        return response;
    }

    public RestfulApiResponse UpdateSingleConcept(string oid, string language, string codeToReplace, string? newCode = null, string? newCodeSystem = null, string? newDisplayName = null)
    {
        var response = new RestfulApiResponse();

        // Find existing valueset based on OID and language
        var valueSetIndex = _valueSets.FindIndex(vs => vs.Id == oid && vs.Language == language);

        if (valueSetIndex == -1)
        {
            _logger.LogWarning($"No value set with oid: {oid}, language: {language}");
            response.SetMessage($"No value set with oid: {oid}, language: {language}");
            return response;
        }

        var valueSet = _valueSets[valueSetIndex];

        var conceptIndex = Array.FindIndex(valueSet.ConceptList.Concept, vs => vs.Code == codeToReplace);

        if (conceptIndex == -1)
        {
            _logger.LogWarning($"No concept with code: {codeToReplace}");
            response.SetMessage($"No concept with code: {codeToReplace}");
            return response;
        }

        var theConcept = valueSet.ConceptList.Concept[conceptIndex];

        valueSet.ConceptList.Concept[conceptIndex] = new()
        {
            Code = newCode ?? codeToReplace,
            CodeSystemName = newCodeSystem ?? theConcept.CodeSystemName,
            DisplayName = newDisplayName ?? theConcept.DisplayName,
        };

        _valueSetRepositoryWrapper.WriteValueSet(oid, language, valueSet);
        _valueSets = _valueSetRepositoryWrapper.ReadAllValueSets();

        return response;
    }

    public RestfulApiResponse DeleteConcept(string oid, string language, string code)
    {
        var response = new RestfulApiResponse();

        var valueSetIndex = _valueSets.FindIndex(vs => vs.Id == oid && vs.Language == language);

        if (valueSetIndex == -1)
        {
            _logger.LogWarning($"No value set with oid: {oid}, language: {language}");
            response.SetMessage($"No value set with oid: {oid}, language: {language}");
            return response;
        }

        var valueSet = _valueSets[valueSetIndex];


        var conceptIndex = Array.FindIndex(valueSet.ConceptList.Concept, vs => vs.Code == code);

        if (conceptIndex == -1)
        {
            _logger.LogWarning($"No concept with code: {code}");
            response.SetMessage($"No concept with code: {code}");
            return response;
        }

        var valueSetWithoutConcept = valueSet.ConceptList.Concept.ToList();
        valueSetWithoutConcept.RemoveAt(conceptIndex);

        valueSet.ConceptList.Concept = valueSetWithoutConcept.ToArray();

        _logger.LogWarning($"Deleted concept with code: {code}");
        response.SetMessage($"Deleted concept with code: {code}");

        _valueSetRepositoryWrapper.WriteValueSet(oid, language, valueSet);
        _valueSets = _valueSetRepositoryWrapper.ReadAllValueSets();

        return response;
    }

    public RestfulApiResponse RenameValueSet(string oid, string language, string? newOid, string? newLanguage)
    {
        throw new NotImplementedException();
    }

    public RestfulApiResponse DeletValueSet(string oid, string language)
    {
        throw new NotImplementedException();
    }
}
