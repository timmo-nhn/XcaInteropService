using XcaInteropService.Source.Services;

namespace XcaInteropService.Commons.Models.Custom;

public class TargetCommunitiesService
{
    private readonly ILogger<TargetCommunitiesService> _logger;

    private readonly TargetCommunitiesWrapper _targetCommunitiesWrapper;

    private readonly FileSystemWatcher _watcher;

    private DomainConfigMap _domainConfig;

    private readonly string _domainConfigPath;

    private readonly string _domainConfigFile;

    public TargetCommunitiesService(ILogger<TargetCommunitiesService> logger, TargetCommunitiesWrapper targetCommunitiesWrapper)
    {
        _logger = logger;
        _targetCommunitiesWrapper = targetCommunitiesWrapper;

        RefreshDomainConfig();
        
        _domainConfigPath = _targetCommunitiesWrapper.GetDomainConfigPath();
        _domainConfigFile = _targetCommunitiesWrapper.GetDomainConfigFile();


        _watcher = new FileSystemWatcher(_domainConfigPath)
        {
            Filter = Path.GetFileName(_domainConfigFile),
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
        };

        _watcher.Changed += OnConfigFileChanged;
        _watcher.EnableRaisingEvents = true;
    }

    private void OnConfigFileChanged(object sender, FileSystemEventArgs e)
    {
        try
        {
            _logger.LogInformation($"{Path.GetFileName(_domainConfigFile)} reloaded successfully.");

            RefreshDomainConfig();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reloading domain config.");
        }
    }


    public DomainConfigMap GetDomainConfigMap()
    {
        return _domainConfig;
    }

    public bool UpdateDomainConfigMap(DomainConfig domainConfig)
    {
        _domainConfig.Domains ??= new();
        _domainConfig.Domains.Add(domainConfig);

        var result = _targetCommunitiesWrapper.WriteConfigMap(_domainConfig);

        if (result == true)
        {
            RefreshDomainConfig();
            return true;
        }
        return result;
    }

    public bool RemoveDomainConfig(string oid)
    {
        var idx = _domainConfig.Domains.FindIndex(dom => dom.DomainOid == oid);

        if (idx == -1) return false;
        
        _domainConfig.Domains.RemoveAt(idx);

        var result = _targetCommunitiesWrapper.WriteConfigMap(_domainConfig);

        if (result == true)
        {
            RefreshDomainConfig();
            return true;
        }
        return result;
    }

    public bool ToggleDomain(string oid, out bool? currentValue)
    {
        var theDomain = _domainConfig.Domains.FirstOrDefault(dom => dom.DomainOid == oid);
        
        
        if (theDomain == null)
        {
            currentValue = null;
            return false;
        }

        theDomain.Enabled = !theDomain.Enabled;
        
        currentValue = theDomain.Enabled;
        
        var result = _targetCommunitiesWrapper.WriteConfigMap(_domainConfig);

        if (result)
            RefreshDomainConfig();

        return result;
    }

    private void RefreshDomainConfig()
    {
        _domainConfig = _targetCommunitiesWrapper.ReadDomainConfigMap();
    }

}
