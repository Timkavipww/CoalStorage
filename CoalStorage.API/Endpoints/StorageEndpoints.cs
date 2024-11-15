namespace CoalStorage.API.Endpoints;

public static class StorageEndpoints
{
    public static void AddStorageEndpoints(this WebApplication app)
    {
        app.MapGet("/api/storages", GetAllStorages).WithName("Get Storages").Produces<APIResponse>(200).Produces(400);
        app.MapGet("/api/storages/{id:int}", GetStorageById).WithName("Get Storage By Id").Produces<APIResponse>(200).Produces(404);
        app.MapPost("/api/storages", CreateStorage).WithName("Create Storage").Produces<APIResponse>(201).Produces(400);
        app.MapPut("/api/storages", UpdateStorage).WithName("Update Storage").Produces<APIResponse>(201).Produces(400);
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
                        AreaName = area.AreaName,
                        MainStorageId = area.MainStorageId,
                        Pickets = area.Pickets.Select(picket => new PicketDTO
                        {
                            Id = picket.Id,
                            Load = picket.Load,
                            AreaId = area.Id,
                            MainStorageId = area.MainStorageId
                        }).ToList(),
                        TotalLoad = area.TotalLoad
                    }).ToList()
                }).ToList();

                response.Success(result);
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
    /// GET STORAGE BY ID
    private static async Task<IResult> GetStorageById(long id, IStorageRepository _context)
    {
        var response = new APIResponse();
        try
        {
            var storage = await _context.GetStorageByIdAsync(id);

            if (storage != null)
            {
                var result = storage.ToDTO();
                response.Success(result);
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
            var storageEntity = storageFromBody.ToEntity();
            storageEntity = new MainStorage
            {
                StorageName = storageFromBody.StorageName,
                Created = DateTime.Now,
                CreatedBy = "Admin"
            };
            await _context.CreateStorageAsync(storageEntity);
            await _context.SaveChangesAsync();

            response.Success();
            response.Created(storageEntity);

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
            await _context.RemoveStorageAsync(storage);
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
    private static async Task<IResult> UpdateStorage([FromQuery] long id, [FromBody] MainStorageCreateDTO storageFromBody, IStorageRepository _context)
    {
        var response = new APIResponse();

        try
        {
            var existingStorage = await _context.GetStorageByIdAsync(id);

            if (existingStorage == null)
            {
                existingStorage = new MainStorage
                {
                    StorageName = storageFromBody.StorageName,
                    LastModified = DateTime.UtcNow,
                    LastModifiedBy = "admin"
                };
                await _context.CreateStorageAsync(existingStorage);
                await _context.SaveChangesAsync();
                response.Created(existingStorage);
                response.Result = $"Created new storage {existingStorage.StorageName}.";
                return Results.Created();
            }
            else
            {

                existingStorage.StorageName = storageFromBody.StorageName;
                existingStorage.LastModified = DateTime.UtcNow; 
                existingStorage.LastModifiedBy = "admin";  

                await _context.UpdateStorageAsync(existingStorage);
            }
            await _context.SaveChangesAsync();

            response.Success();
            response.Result = $"Updated storage {existingStorage.StorageName}.";

            return Results.Ok(response);
        }
        catch (DbException dbEx)
        {
            response.ErrorMessages.Add($"Database error: {dbEx.Message}");
            return Results.BadRequest(response);
        }
        catch (Exception ex)
        {
            response.ErrorMessages.Add($"Unexpected error: {ex.Message}");
            return Results.BadRequest(response);
        }
    }
}
