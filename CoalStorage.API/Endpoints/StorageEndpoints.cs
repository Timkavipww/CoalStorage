
namespace CoalStorage.API.Endpoints;

public static class StorageEndpoints
{
    public static void AddStorageEndpoints(this WebApplication app)
    {
        app.MapGet("/api/storages", GetAllStorages).WithName("Get Storages").Produces<APIResponse>(200).Produces(400);
        app.MapGet("/api/storages/{id:int}", GetStorageById).WithName("Get Storage By Id").Produces<APIResponse>(200).Produces(404);
        app.MapPost("/api/storages", CreateStorage).WithName("Create Storage").Produces<APIResponse>(201).Produces(400);
        app.MapPut("/api/storages", UpdateStorageById).WithName("Update Storage").Produces<APIResponse>(201).Produces(400);
        app.MapDelete("api/storages", RemoveStorageById).WithName("Delete Storage").Produces<APIResponse>(200).Produces(400);
    }

    ///GET ALL STORAGES
    private static async Task<IResult> GetAllStorages(IStorageRepository _context)
    {
        var response = new APIResponse();
        try
        {
            var storages = await _context.GetAllStoragesAsync();

            if (storages != null && storages.Any())
            {
                var result = storages.Select(storage => new MainStorageDTO
                {
                    Id = storage.Id,
                    StorageName = storage.StorageName,
                    Areas = storage.Areas.Select(area => new AreaDTO
                    {
                        Id = area.Id,
                        AreaName = area.AreaName ?? "Unknown", // Можно указать значение по умолчанию
                        MainStorageId = area.MainStorageId,
                        Pickets = area.AreaPickets?.Select(picket => new PicketDTO
                        {
                            Id = picket.Id,
                            AreaId = area.Id,
                            MainStorageId = area.MainStorageId
                        }).ToList(),
                    }).ToList()

                }).ToList();

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                    WriteIndented = true // Опционально для улучшения читаемости
                };

                var json = JsonSerializer.Serialize(result, options);

                response.Success(result);
                return Results.Ok(response);
            }
            else
            {
                return Results.NotFound(response);
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
    }

    /// GET STORAGE BY ID
    private static async Task<IResult> GetStorageById(long id, IStorageRepository _context)
    {
        var response = new APIResponse();
        try
        {
            var storage = await _context.GetStorageByIdAsync(id);

            


            if (storage != null)
            {
                var newStorage = storage.ToDTO();

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                    WriteIndented = true // Опционально для улучшения читаемости
                };

                var json = JsonSerializer.Serialize(newStorage, options);

                response.Success(newStorage);
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

    /// CREATE STORAGE
    private static async Task<IResult> CreateStorage ([FromBody] MainStorageCreateDTO storageFromBody, IStorageRepository _context)
    {
        var response = new APIResponse();
        try
        {
            if (storageFromBody == null)
            {
                response.Message += "Empty body";
                return Results.BadRequest(response);
            }

                var storage = storageFromBody.ToEntity();

                await _context.CreateStorageAsync(storage);

                await _context.SaveChangesAsync();

                response.Created(storage);

                return Results.Created();
        }
        catch (DbException dbEx)
        {
            return Results.BadRequest(response.DbException(dbEx));
        }
        catch (Exception ex)
        {
            return Results.BadRequest(response.FatalException(ex));
        }
    }

    ///RemoveStorageById
    private static async Task<IResult> RemoveStorageById(long id, IStorageRepository _context)
    {
        var response = new APIResponse();
        try
        {
            var storage = await _context.GetStorageByIdAsync(id);

            if(storage == null)
            {
                response.NotFound();
                return Results.NotFound(response);
            }
            await _context.RemoveStorageAsync(id);
            await _context.SaveChangesAsync();

            response.Success(storage);
            response.Message += $"Deleted storage w/ id {id}";

            return Results.Ok(response);

        }
        catch(DbException dbEx)
        {
            return Results.BadRequest(response.DbException(dbEx));
        }
        catch (Exception ex)
        {
            return Results.BadRequest(response.FatalException(ex));
        }
    }

    //UpdateStorageById
    private static async Task<IResult> UpdateStorageById(long id, [FromBody] MainStorageCreateDTO storageFromBody, IStorageRepository _context)
    {
        var response = new APIResponse();
        try
        {
            var storageExisting = await _context.GetStorageByIdAsync(id);

            storageExisting.StorageName = storageFromBody.StorageName;

            await _context.UpdateStorageAsync(storageExisting);
            await _context.SaveChangesAsync();

            response.Success($"Storage w/Id {id} Updated w/ new Name {storageFromBody.StorageName}");
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
    }
}
