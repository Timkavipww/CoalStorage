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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<MainStorageCargo>()
           .HasKey(wc => new { wc.MainStorageId, wc.AreaId, wc.PicketId });

        // Связь "MainStorageCargo - MainStorage"
        modelBuilder.Entity<MainStorageCargo>()
            .HasOne(wc => wc.MainStorage)
            .WithMany(ms => ms.MainStorageCargos)
            .HasForeignKey(wc => wc.MainStorageId);

        // Связь "MainStorageCargo - Area"
        modelBuilder.Entity<MainStorageCargo>()
            .HasOne(wc => wc.Area)
            .WithMany(a => a.MainStorageCargos)
            .HasForeignKey(wc => wc.AreaId);

        // Связь "MainStorageCargo - Picket"
        modelBuilder.Entity<MainStorageCargo>()
            .HasOne(wc => wc.Picket)
            .WithMany(p => p.MainStorageCargos)
            .HasForeignKey(wc => wc.PicketId);

        // Связь "Area - MainStorage"
        modelBuilder.Entity<Area>()
            .HasOne(a => a.MainStorage)
            .WithMany(ms => ms.Areas)
            .HasForeignKey(a => a.MainStorageId);

        // Связь "Area - Picket"
        modelBuilder.Entity<Picket>()
            .HasOne(p => p.Area)
            .WithMany(a => a.Pickets)
            .HasForeignKey(p => p.AreaId);

        modelBuilder.Entity<MainStorage>()
           .HasMany(ms => ms.Areas)
           .WithOne(a => a.MainStorage)
           .HasForeignKey(a => a.MainStorageId);

        modelBuilder.Entity<MainStorage>()
            .HasMany(ms => ms.Pickets)
            .WithOne(p => p.MainStorage)
            .HasForeignKey(p => p.MainStorageId);
    }
}

