namespace CoalStorage.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();

        await initialiser.InitialiseAsync();

    }
}

    public class AppDbContextInitialiser
    {
        private readonly ILogger<AppDbContextInitialiser> _logger;
        private readonly AppDbContext _context;

        public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.GetPendingMigrations().Any())
            {
                await _context.Database.MigrateAsync();
                _logger.LogInformation("Migrations have been applied.");
            }
            else
            {
                _logger.LogInformation("No pending migrations found.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

}
