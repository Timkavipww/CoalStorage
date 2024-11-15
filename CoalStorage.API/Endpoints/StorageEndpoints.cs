namespace CoalStorage.API.Endpoints;

public static class StorageEndpoints
{
    public static void AddStorageEndpoints(this WebApplication app)
    {
        app.MapGet("/api/storages", GetAllStorages).WithName("Get Storages").Produces<APIResponse>(200).Produces(404);
        app.MapGet("/api/storages/{id:int}", GetStorageById).WithName("Get Storage By Id").Produces<APIResponse>(200).Produces(404);
        app.MapPost("/api/storages", CreateStorage);
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
    private static async Task<IResult> GetStorageById(long id, IStorageRepository _context)
    {
        var response = new APIResponse();
        try
        {
            var storage = await _context.GetByIdAsync(id);
            if (storage != null)
            {
                response.Success(storage);
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
        }W
        return Results.NotFound(response);
    }
    private static async Task<IResult> CreateStorage ([FromBody] MainStorageDTO storageFromBody, IStorageRepository _context)
    {
        var response = new APIResponse();
        try
        {
            var storages = await _context.GetAllStoragesAsync();
            if (storages.FirstOrDefault(u => u.Id == storageFromBody.Id) != null)
            {
                response.Result = $" storage with id : {storageFromBody.Id} already exists";
                return Results.BadRequest(response);
            }
            if (storageFromBody == null)
            {
                response.NotFound();
                return Results.NotFound(response);

            }
                var storage = storageFromBody.toEntity();

                await _context.AddAsync(storage);

                await _context.SaveChangesAsync();

                response.Created(storageFromBody.toEntity());

                return Results.Ok(response);
        }
        catch (DbException dbEx)
        {
            return Results.BadRequest(response.DbException(dbEx));
        }
        catch (Exception ex)
        {
            return Results.BadRequest(response.FatalException(ex));
        }
        return Results.BadRequest(response);
    }
}
