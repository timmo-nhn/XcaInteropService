using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using XcaXds.Source.Source;

namespace XcaInteropService.Source.Services;

public class PatientDemographicsWrapper
{
    private readonly ILogger<PatientDemographicsWrapper> _logger;
    private readonly IDbContextFactory<SqliteRegistryDbContext> _contextFactory;

    private readonly string _connectionString;
    private readonly string _databaseFile;

    public PatientDemographicsWrapper(
        ILogger<PatientDemographicsWrapper> logger,
        IDbContextFactory<SqliteRegistryDbContext> contextFactory)
    {
        _logger = logger;
        _contextFactory = contextFactory;

        _databaseFile = DatabasePathFinder.FindDatabasePath();

        _connectionString = $"Data Source=\"{_databaseFile}\"";

        _logger.LogDebug($"Database connection string: {_connectionString}");

        using var context = _contextFactory.CreateDbContext();
        context.Database.EnsureCreated();
    }

}
