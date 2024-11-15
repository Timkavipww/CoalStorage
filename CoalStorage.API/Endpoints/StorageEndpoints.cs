namespace CoalStorage.API.Endpoints;

public static class StorageEndpoints
{
    public static void AddStorageEndpoints(this WebApplication app)
    {
        app.MapGet("/api/storages", GetAllStorages).WithName("Get Storages").Produces<APIResponse>(200).Produces(400);
        app.MapGet("/api/storages/{id:int}", GetStorageById).WithName("Get Storage By Id").Produces<APIResponse>(200).Produces(404);
        app.MapPost("/api/storages", CreateStorage).WithName("Create Storage").Produces<APIResponse>(201).Produces(400);
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

            ///????
            //if (existingStorage != null)
            //{
            //    response.Result = $"Storage with id: {storageFromBody.Id} already exists";
            //    return Results.BadRequest(response);
            //}

            var newStorage = new MainStorage
            {
                StorageName = storageFromBody.StorageName,
                Created = DateTime.UtcNow.Date,
                CreatedBy = "Admin"
            };
            await _context.CreateStorageAsync(newStorage);
            await _context.SaveChangesAsync();

            response.Success();
            response.Created(newStorage);

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
}
