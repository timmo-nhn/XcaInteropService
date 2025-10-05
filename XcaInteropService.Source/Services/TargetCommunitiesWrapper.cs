using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.RegularExpressions;
using XcaInteropService.Commons.Models.Custom;
using YamlDotNet.Serialization;

namespace XcaInteropService.Source.Services;

public class TargetCommunitiesWrapper
{
    private readonly ILogger<TargetCommunitiesWrapper> _logger;

    internal string _domainConfigPath;
    internal string _domainConfigFile;
    private readonly object _lock = new object();

    public TargetCommunitiesWrapper(ILogger<TargetCommunitiesWrapper> logger)
    {
        _logger = logger;

        string baseDirectory = AppContext.BaseDirectory;
        _domainConfigPath = Path.Combine(baseDirectory, "..", "..", "..", "..", "XcaInteropService.Source", "Data", "DomainConfig");
        _domainConfigFile = Path.Combine(_domainConfigPath, "DomainConfig.yml");
        EnsureDomainConfigFileExists();
        ReadDomainConfigMap();
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

            domainConfigMap.Domains.ForEach(domain =>
            {
                // Put validation logic or other stuff here

                domain.RetrieveUrl ??= domain.QueryUrl;

                var sb = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(domain.DomainOid) && Regex.IsMatch(domain.DomainOid, @"^[\d\.]+$") == false)
                {
                    sb.AppendLine($"Domain Config DomainOid contains a malformed OID\n\tValue: {domain.DomainOid}");
                }

                if (!string.IsNullOrWhiteSpace(domain.PatientAssigningAuthority) && Regex.IsMatch(domain.PatientAssigningAuthority, @"^[\d\.]+$") == false)
                {
                    sb.AppendLine($"Domain Config PatientAssigningAuthority contains a malformed OID\n\tValue: {domain.PatientAssigningAuthority}");
                }

                if (sb.Length != 0)
                {
                    _logger.LogWarning($"Error while parsing Domain Config {domain.FriendlyName}{sb.ToString()}");
                }

                if (domain.PatientResolverType == Commons.Enums.PatientResolverType.PIX && string.IsNullOrWhiteSpace(domain.PatientAssigningAuthority))
                {
                    domain.PatientAssigningAuthority = domain.DomainOid;
                }
            });

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
