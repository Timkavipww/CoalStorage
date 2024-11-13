namespace CoalStorage.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    { }

    public DbSet<MainStorage> Storages { get; set; }
    public DbSet<Picket> Pickets { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<PicketArea> PicketAreas { get; set; }
    public DbSet<StoragePicket> StoragePickets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка связи между Area и MainStorage
        modelBuilder.Entity<Area>()
            .HasOne(a => a.MainStorage)
            .WithMany(ms => ms.Areas)
            .HasForeignKey(a => a.MainStorageId);

        // Остальные настройки связей
        modelBuilder.Entity<PicketArea>()
            .HasKey(pa => new { pa.PicketID, pa.AreaID });

        modelBuilder.Entity<PicketArea>()
            .HasOne(pa => pa.Picket)
            .WithMany(p => p.PicketAreas)
            .HasForeignKey(pa => pa.PicketID);

        modelBuilder.Entity<PicketArea>()
            .HasOne(pa => pa.Area)
            .WithMany(a => a.PicketAreas)
            .HasForeignKey(pa => pa.AreaID);

        modelBuilder.Entity<StoragePicket>()
            .HasKey(sp => new { sp.StorageID, sp.PicketID });

        modelBuilder.Entity<StoragePicket>()
            .HasOne(sp => sp.MainStorage)
            .WithMany(ms => ms.StoragePickets)
            .HasForeignKey(sp => sp.StorageID);

        modelBuilder.Entity<StoragePicket>()
            .HasOne(sp => sp.Picket)
            .WithMany(p => p.StoragePickets)
            .HasForeignKey(sp => sp.PicketID);
    }

}
