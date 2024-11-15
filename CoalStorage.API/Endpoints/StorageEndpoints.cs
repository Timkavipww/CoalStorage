namespace CoalStorage.API.Endpoints;

public static class StorageEndpoints
{
    public static void AddStorageEndpoints(this WebApplication app)
    {
        app.MapGet("/api/storages", GetAllStorages).WithName("Get Storages").Produces<APIResponse>(200).Produces(404);
    }

   private static async Task<IResult> GetAllStorages(IStorageRepository _context)
    {
        var response = new APIResponse();
        try
        {
            var storages = await _context.GetAllStoragesAsync();
            if (storages != null)
            {
                response.Success(storages);
                return Results.Ok(response);
            }
        }
        catch (DbException dbEx)
        {
            return Results.BadRequest(response.DbException(dbEx));
        }
        catch (Exception ex)
        {
            return Results.BadRequest(response.FatalException(ex));
        }
        return Results.NotFound(response);
    }
}
