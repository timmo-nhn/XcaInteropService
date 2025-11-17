using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using XcaInteropService.Commons.Models.Custom.PatientIdentityDtos;
using XcaInteropService.Source.Models.DatabaseDtos;
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

    public IEnumerable<PatientIdentityDto?> ReadPatientDemographics()
    {
        using var db = _contextFactory.CreateDbContext();
        foreach (var entity in db.PatientIdentityList.AsNoTracking())
        {
            yield return DatabaseMapper.MapFromDatabaseEntityToDto(entity);
        }
    }

    public bool UpdatePatientDemographics(List<PatientIdentityDto?>? dtos)
    {
        using var db = _contextFactory.CreateDbContext();

        db.ChangeTracker.AutoDetectChangesEnabled = false;

        var dbEntities = DatabaseMapper.MapFromDtoToDatabaseEntity(dtos);
        db.PatientIdentityList.AddRange(dbEntities);
        db.SaveChanges();
        return true;
    }
}
