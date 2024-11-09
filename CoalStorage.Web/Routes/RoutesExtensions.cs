namespace CoalStorage.Web.Routes;
/// <summary>
/// Routes Extensions
/// </summary>
public static class RoutesExtensions
{
    
    public static void AddRoutes(this WebApplication app)
    {

        app.MapGet("/", () =>
        {
            return new { name = "xd", age = 17 };
        });
        app.MapGet("/storages", async (AppDbContext _context) =>
        {
            var warehouses = await _context.Storages.ToListAsync();
            return Results.Ok(warehouses);
        });

    }
}
