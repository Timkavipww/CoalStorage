namespace CoalStorage.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    { }

    public DbSet<MainStorage> MainStorages { get; set; }
    public DbSet<Picket> Pickets { get; set; }
    public DbSet<Area> Areas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
     
    }
}

