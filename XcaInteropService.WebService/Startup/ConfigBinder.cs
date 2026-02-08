namespace XcaInteropService.WebService.Startup;

public static class ConfigBinder
{
    public static ApplicationConfig BindKeyValueEnvironmentVariablesToXdsConfiguration(List<KeyValuePair<string, string>> xdsConfigEnvVars)
    {
        var useCompositeOid = bool.Parse(xdsConfigEnvVars.FirstOrDefault(f => f.Key == "XdsConfiguration__UseCompositeObjectIdentifiers").Value ?? "false");

        var rootOid = xdsConfigEnvVars.FirstOrDefault(f => f.Key == "XdsConfiguration__RootOid").Value;
        var valueSetOid = xdsConfigEnvVars.FirstOrDefault(f => f.Key == "XdsConfiguration__ValueSetRootOid").Value.TrimStart('.');
        var patientIdentitySource = xdsConfigEnvVars.FirstOrDefault(f => f.Key == "XdsConfiguration__PatientIdentitySource").Value.TrimStart('.');
        var globalPatientAssAuth = xdsConfigEnvVars.FirstOrDefault(f => f.Key == "XdsConfiguration__GlobalPatientAssigningAuthority").Value.TrimStart('.');

        return new()
        {
            TimeoutInSeconds = int.Parse(xdsConfigEnvVars.FirstOrDefault(f => f.Key == "XdsConfiguration__TimeoutInSeconds").Value ?? "0"),
            SsnAssigningAuthority = xdsConfigEnvVars.FirstOrDefault(f => f.Key == "XdsConfiguration__SsnAssigningAuthority").Value,

            RootOid = rootOid,
            ValueSetRootOid = useCompositeOid ? rootOid + "." + valueSetOid : valueSetOid,
            PatientIdentitySource = useCompositeOid ? rootOid + "." + patientIdentitySource : patientIdentitySource,
            GlobalPatientAssigningAuthority = useCompositeOid ? rootOid + "." + globalPatientAssAuth : globalPatientAssAuth,
        };
    }
}