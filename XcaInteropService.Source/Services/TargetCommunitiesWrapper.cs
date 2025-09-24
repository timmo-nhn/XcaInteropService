using XcaInteropService.Commons.Models.Custom;
using YamlDotNet.Serialization;

namespace XcaInteropService.Source.Services;

public class TargetCommunitiesWrapper
{
    internal string _domainConfigPath;
    internal string _domainConfigFile;

    public TargetCommunitiesWrapper()
    {
        string baseDirectory = AppContext.BaseDirectory;
        _domainConfigPath = Path.Combine(baseDirectory, "..", "..", "..", "..", "XcaInteropService.Source", "Data", "DomainConfig");
        _domainConfigFile = Path.Combine(_domainConfigPath, "DomainConfig.yml");
    }

    public DomainConfigMap ReadDomainConfigMap()
    {
        var content = File.ReadAllText(_domainConfigFile);

        var deserializer = new Deserializer();
        var domainConfigMap = deserializer.Deserialize<DomainConfigMap>(content);

        return domainConfigMap;
    }

    public bool WriteConfigMap(DomainConfigMap domainConfigMap)
    {
        var serializer = new Serializer();

        var domainConfigMapYaml = serializer.Serialize(domainConfigMap);

        File.WriteAllText(_domainConfigFile, domainConfigMapYaml);

        return true;
    }
}
