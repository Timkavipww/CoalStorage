namespace CoalStorage.API.Endpoints;

public static class AreaEndpoints
{
    public static void AddAreaEndpoints(this WebApplication app)
    {
        app.MapGet("/api/storages/{storageId:int}/areas/{storageId:int}", GetAllAreaByStorageId);
        app.MapGet("api/storages/{storageId:int}/areas", GetAllAreasByStorageId);
        //app.MapPost("/api/storage/{id:int}/areas", AddAreaByStorageId);
        app.MapDelete("/api/storages/{storageId:int}/areas/{areaId:int}", RemoveAreaByStorageId);
        app.MapPost("api/storages/{storageId:int}/areas", CreateAreaByStorageId);
        app.MapPut("api/storages/{storageId:int}/areas", UpdateAreaByStorageId);
    }
    //GET AREA BY STORAGE ID
    private static async Task<IResult> GetAllAreaByStorageId(long storageId, IAreaRepository _context)
    {
        var response = new APIResponse();
        try
        {

            var areas = await _context.GetAreasByStorageIdAsync(storageId);
            if (areas.Any())
            {
                var result = areas.Select(area => area.ToDTO()).ToList();
                response.Success(result);
                return Results.Ok(result);
            }
            return Results.BadRequest(response);

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
    //GET ALL AREAS BY STORAGE ID
    private static async Task<IResult> GetAllAreasByStorageId(IAreaRepository _context)
    {
        var response = new APIResponse();

        try
        {
            var area = await _context.GetAllAreasAsync();
            var result = area.Select(area => area.ToDTO());
            response.Success(result);
            return Results.Ok(result);

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
    //REMOVE AREA BY STORAGE ID
    private static async Task<IResult> RemoveAreaByStorageId(long Id, IAreaRepository _context)
    {
        var response = new APIResponse();

        try
        {
            var area = await _context.GetAreaByIdAsync(Id);

            if (area == null)
            {
                response.NotFound();
                return Results.NotFound();
            }
            var result = area.ToDTO();
            response.Success(result);
            return Results.Ok(result);


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
    //CREATE AREA BY STORAGE ID
    private static async Task<IResult> CreateAreaByStorageId([FromBody] AreaCreateDTO areaFromBody, IAreaRepository _context)
    {
        var response = new APIResponse();


        try
        {

            var areaDTO = areaFromBody.toEntity();

            await _context.CreteAreaAsync(areaDTO);
            await _context.SaveChangesAsync();
           
            response.Created(areaDTO);
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
    //UPDATE AREA BY STORAGE ID
    private static async Task<IResult> UpdateAreaByStorageId(long storageId, int areaId, [FromBody] AreaUpdateDTO areaFromBody, IAreaRepository _context)
    {
        var response = new APIResponse();
        try
        {
            var existingAreas = await _context.GetAreasByStorageIdAsync(storageId);
            var existArea = await _context.GetAreaByIdAsync(areaId);

            if (existArea == null)
            {
                response.Result = "not found area";
            return Results.NotFound(response);
            }

            existArea.MainStorageId = areaFromBody.MainStorageId;
            await _context.UpdateAreaAsync(existArea);
            await _context.SaveChangesAsync();

            return Results.Ok();
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