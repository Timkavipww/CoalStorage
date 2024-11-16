using CoalStorage.Core.Entities.DTO;

namespace CoalStorage.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    { }

    public DbSet<MainStorage> MainStorages { get; set; }
    public DbSet<Picket> Pickets { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<MainStorageCargo> MainStorageCargos { get; set; }
    public DbSet<AreaPickets> AreaPickets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<MainStorageCargo>()
           .HasAlternateKey(u => new { u.PicketId, u.MainStorageId, u.AreaId });

        modelBuilder.Entity<MainStorage>()
       .Property(m => m.Created)
       .HasConversion(
           v => v.ToUniversalTime(),
           v => v);

     
    }
}

