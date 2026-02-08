using XcaInteropService.Commons.Commons;

namespace XcaInteropService.WebService.Services;

public class MonitoringStatusService
{
    public DateTimeOffset StartupTime { get; set; }
    public BoundedDictionary<string,long> ResponseTimes { get; set; }
    public MonitoringStatusService()
    {
        ResponseTimes = new();
    }
}