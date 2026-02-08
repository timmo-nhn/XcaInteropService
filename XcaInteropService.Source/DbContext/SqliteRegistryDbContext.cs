using Microsoft.EntityFrameworkCore;
using XcaInteropService.Source.Models.DatabaseDtos;

namespace XcaInteropService.Source.Source;

public class SqliteRegistryDbContext : DbContext
{
    public DbSet<DbPatientIdentityDto> PatientIdentityList => Set<DbPatientIdentityDto>();

    private readonly string _dbPath;

    public SqliteRegistryDbContext(DbContextOptions<SqliteRegistryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbPatientIdentityDto>().UseTpcMappingStrategy();

        modelBuilder.Entity<DbPatientIdentityDto>().ToTable("PatientIdentityRegistry");

        var patient = modelBuilder.Entity<DbPatientIdentityDto>();

        patient.HasKey(x => x.Id);

        patient.OwnsMany(p => p.AlternatePatientIdentifiers, a =>
        {
            a.WithOwner().HasForeignKey("PatientIdentityId");
            a.ToTable("PatientIdentity_AlternateIdentifiers");
            a.Property(x => x.Id).ValueGeneratedOnAdd();
        });
    }
}