using System.Text.Json;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.WebService.Services;

namespace XcaInteropService.WebService.Startup;

public class AppStartupService : IHostedService
{
    private readonly ILogger<AppStartupService> _logger;
    private readonly IHostEnvironment _env;
    private readonly IConfiguration _config;
    private readonly ApplicationConfig _appConfig;
    private readonly MonitoringStatusService _monitoringService;
    private readonly ValueSetRepositoryService _valueSetRepositoryService;
    private readonly TargetCommunitiesService _targetCommunitiesService;

    public AppStartupService(
        ILogger<AppStartupService> logger,
        IHostEnvironment env,
        IConfiguration config,
        ApplicationConfig appConfig,
        MonitoringStatusService monitoringService,
        ValueSetRepositoryService valueSetRepositoryService,
        TargetCommunitiesService targetCommunitiesService
        )
    {
        _logger = logger;
        _env = env;
        _config = config;
        _appConfig = appConfig;
        _monitoringService = monitoringService;
        _valueSetRepositoryService = valueSetRepositoryService;
        _targetCommunitiesService = targetCommunitiesService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var startupTime = DateTime.Now;
        _logger.LogInformation($"Startup Time (UTC): {startupTime:O}");
        _logger.LogDebug($"App config: {JsonSerializer.Serialize(_appConfig)}");

        _monitoringService.StartupTime = startupTime;

        if (_env.IsProduction())
        {
            if (_appConfig.RootOid == "2.16.578.1.12.4.5.200.3.1")
            {
                _logger.LogCritical($"\n\n========  Fatal! Default Root OID in production =======\nDefault HomeCommunity Id {_appConfig.RootOid}! \nWhen deploying the application, please change this to an unique OID\n\n");
                throw new InvalidOperationException("Default Root OID used in production environment.");
            }
        }

        if (_appConfig.RootOid == "2.16.578.1.12.4.5.200.3.1")
        {
            _logger.LogWarning($"\n\n========  Warning! Default HomeCommunityId =======\nUsing default HomeCommunity Id {_appConfig.RootOid}! \nWhen deploying the application, please change this to an unique OID\n\n");
        }

        _logger.LogInformation("Starting XcaInteropService...");

        SetupDefaultValueSets();

        return Task.CompletedTask;
    }

    private void SetupDefaultValueSets()
    {
        _valueSetRepositoryService.UploadSingleConcept("oid_sources", Constants.Svcm.Languages.English, _appConfig.SsnAssigningAuthority ?? Constants.Oid.Fnr, null, _appConfig.SsnAssigningAuthority == Constants.Oid.Fnr ? "Folkeregisterert (FNR)" : "Social Security Number");

        var domainsUsingPix = _targetCommunitiesService.GetDomainConfigMap().Domains.Where(dom => dom.PatientResolverType == Commons.Enums.PatientResolverType.PIX);

        foreach (var domain in domainsUsingPix)
        {
            _valueSetRepositoryService.UploadSingleConcept("oid_sources", Constants.Svcm.Languages.English, domain.HomeCommunityId, null, domain.FriendlyName);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping XcaInteropService...");
        return Task.CompletedTask;
    }
}
