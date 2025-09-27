using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Commons.Models.Custom.RegistryDtos;
using YamlDotNet.Serialization;

namespace XcaInteropService.Source.Services;

public class TargetCommunitiesWrapper
{
    internal string _domainConfigPath;
    internal string _domainConfigFile;
    private readonly object _lock = new object();


    public TargetCommunitiesWrapper()
    {
        string baseDirectory = AppContext.BaseDirectory;
        _domainConfigPath = Path.Combine(baseDirectory, "..", "..", "..", "..", "XcaInteropService.Source", "Data", "DomainConfig");
        _domainConfigFile = Path.Combine(_domainConfigPath, "DomainConfig.yml");
        EnsureDomainConfigFileExists();
    }

    public string GetDomainConfigPath()
    {
        return _domainConfigPath;
    }

    public string GetDomainConfigFile()
    {
        return _domainConfigFile;
    }

    public DomainConfigMap ReadDomainConfigMap()
    {
        lock (_lock)
        {
            var content = File.ReadAllText(_domainConfigFile);

            var deserializer = new Deserializer();
            var domainConfigMap = deserializer.Deserialize<DomainConfigMap>(content);

            domainConfigMap.Domains.ForEach(domain => domain.RetrieveUrl ??= domain.QueryUrl);

            return domainConfigMap;
        }
    }

    public bool WriteConfigMap(DomainConfigMap domainConfigMap)
    {
        lock (_lock)
        {
            var serializer = new Serializer();

            var domainConfigMapYaml = serializer.Serialize(domainConfigMap);

            File.WriteAllText(_domainConfigFile, domainConfigMapYaml);

            return true;
        }
    }

    private void EnsureDomainConfigFileExists()
    {
        lock (_lock)
        {
            if (!Directory.Exists(_domainConfigPath))
            {
                Directory.CreateDirectory(_domainConfigPath);
            }

            if (!File.Exists(_domainConfigFile))
            {

                using (File.Create(_domainConfigFile)) { }

                WriteConfigMap(new DomainConfigMap());
            }
        }
    }

}
