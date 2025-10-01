namespace XcaXds.WebService.Startup;

public static class ConfigBinder
{
    public static ApplicationConfig BindKeyValueEnvironmentVariablesToXdsConfiguration(List<KeyValuePair<string, string>> xdsConfigEnvVars)
    {
        return new()
        {
            ValueSetRootOid = xdsConfigEnvVars.FirstOrDefault(f => f.Key == "XdsConfiguration__DocumentUploadSizeLimitKb").Value,
            TimeoutInSeconds = int.Parse(xdsConfigEnvVars.FirstOrDefault(f => f.Key == "XdsConfiguration__TimeoutInSeconds").Value ?? "0"),
        };
    }
}