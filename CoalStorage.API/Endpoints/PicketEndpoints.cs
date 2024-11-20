namespace CoalStorage.API.Endpoints;

public static class PicketEndpoints
{
    public static void AddPicketEndpoints(this WebApplication app)
    {
        app.MapGet("/api/storages/{storageId:int}/pickets", GetAllPicketsByStorageId);
        app.MapGet("/api/storages/{storageId:int}/pickets/{picketId:int}", GetPicketById).WithDescription("Get picket by storage ID and picket ID");
        app.MapPost("/api/storages/{storageId:int}/pickets", AddPicketToStorage);
        app.MapDelete("/api/storages/{storageId:int}/pickets/{picketId:int}", RemovePicketFromStorage);
        //app.MapPut("api/storages/{storageId:int}/pickets/{picketId:int}", )
    }
    private static async Task<IResult> GetAllPicketsByStorageId(int storageId, IStorageRepository storageRepository)
    {
        var response = new APIResponse();
        try
        {
            var storage = await storageRepository.GetStorageByIdAsync(storageId);
            if (storage?.Pickets != null && storage.Pickets.Any())
            {
                response.Success(storage.Pickets);
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

    private static async Task<IResult> GetPicketById(int storageId, int picketId, IStorageRepository storageRepository)
    {
        var response = new APIResponse();
        try
        {
            var storage = await storageRepository.GetStorageByIdAsync(storageId);
            var picket = storage?.Pickets.FirstOrDefault(p => p.Id == picketId);

            if (picket != null)
            {
                response.Success(picket);
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

    private static async Task<IResult> AddPicketToStorage(int storageId, [FromBody] PicketDTO picket, IStorageRepository storageRepository)
    {
        var response = new APIResponse();

        try
        {
            var storage = await storageRepository.GetStorageByIdAsync(storageId);
            if (storage != null)
            {
                storage.Pickets.Add(picket.ToEntity());
                await storageRepository.SaveChangesAsync();
                response.Success("Picket added successfully");
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

    private static async Task<IResult> RemovePicketFromStorage(int storageId, int picketId, IStorageRepository storageRepository)
    {
        var response = new APIResponse();

        try
        {
            var storage = await storageRepository.GetStorageByIdAsync(storageId);
            var picket = storage?.Pickets.FirstOrDefault(p => p.Id == picketId);

            if (picket != null)
            {
                storage.Pickets.Remove(picket);
                await storageRepository.SaveChangesAsync();
                response.Success("Picket removed successfully");
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
