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
        ///adding a coal storage connection to other elements
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
            .HasKey(wp => new { wp.StorageID, wp.PicketID });

        modelBuilder.Entity<StoragePicket>()
            .HasOne(wp => wp.MainStorage)
            .WithMany(w => w.StoragePickets)
            .HasForeignKey(wp => wp.StorageID);

        modelBuilder.Entity<StoragePicket>()
            .HasOne(wp => wp.Picket)
            .WithMany(p => p.StoragePickets)
            .HasForeignKey(wp => wp.PicketID);
    }
}
