namespace XcaInteropService.Source.Services;

public static class DatabasePathFinder
{
    public static string FindDatabasePath()
    {
        // When running in a container the path will be different
        var customPath = Environment.GetEnvironmentVariable("PATIENTIDENTITYREGISTRY_FILE_PATH");

        string databasePath;

        if (!string.IsNullOrWhiteSpace(customPath))
        {
            databasePath = customPath;
        }
        else
        {
            string baseDirectory = AppContext.BaseDirectory;
            databasePath = Path.Combine(baseDirectory, "..", "..", "..", "..", "XcaInteropService.Source","Data", "PatientIdentityRegistry");
        }
        databasePath = Path.GetFullPath(databasePath); // resolve ".."

        Directory.CreateDirectory(databasePath);

        return Path.Combine(databasePath, "Registry.db");
    }
}
