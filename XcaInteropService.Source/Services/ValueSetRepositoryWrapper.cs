using Microsoft.Extensions.Logging;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.XdsTypes;
using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Source.Services;

public class ValueSetRepositoryWrapper
{
    internal string _valueSetRepositoryPath;
    private readonly object _lock = new object();

    private readonly ILogger<ValueSetRepositoryWrapper> _logger;
    private readonly ApplicationConfig _applicationConfig;

    public ValueSetRepositoryWrapper(ApplicationConfig applicationConfig, ILogger<ValueSetRepositoryWrapper> logger)
    {
        _logger = logger;
        _applicationConfig = applicationConfig;

        string baseDirectory = AppContext.BaseDirectory;
        _valueSetRepositoryPath = Path.Combine(baseDirectory, "..", "..", "..", "..", "XcaInteropService.Source", "Data", "ValueSetRepository");
    }

    public List<ValueSetType> ReadAllValueSets()
    {
        var valueSets = new List<ValueSetType>();
        var sxmls = new SoapXmlSerializer();

        lock (_lock)
        {
            foreach (var file in Directory.GetFiles(_valueSetRepositoryPath))
            {
                var valueSetString = File.ReadAllText(file);
                if (string.IsNullOrWhiteSpace(valueSetString)) continue;

                var valueSet = sxmls.DeserializeXmlString<ValueSetType>(valueSetString);
                if (valueSet != null && valueSet.Id != null)
                {
                    valueSets.Add(valueSet);
                }
            }

            return valueSets;
        }
    }

    public bool WriteValueSet(string id, string language, ValueSetType valueSet)
    {
        var sxmls = new SoapXmlSerializer();

        var valueSetString = sxmls.SerializeToXmlString(valueSet, Constants.XmlDefaultOptions.DefaultXmlWriterSettings);
        File.WriteAllText(Path.Combine(_valueSetRepositoryPath, $"{id}-{language}"), valueSetString.Content);

        return true;
    }

    public void DeleteConcept(string oid, ConceptType conceptId)
    {
        
    }

    public void DeleteValueSet(string oid)
    {
        throw new NotImplementedException();
    }
}
