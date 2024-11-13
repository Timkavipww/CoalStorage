namespace CoalStorage.API.Endpoints;

public static class AreaEndpoints
{
    public static void AddAreaEndpoints(this WebApplication app)
    {
        app.MapGet("/api/storage/{id:int}/areas", GetAllAreaByStorageId);
        app.MapGet("/api/storage/{id:int}/areas/{areaId:int}", GetAreaByStorageId) // Изменено на areaId
            .WithDescription("get area by storage id");
        app.MapPost("/api/storage/{id:int}/areas", AddAreaByStorageId);
    }
    private static async Task<IResult> GetAllAreaByStorageId(int storageID, int areaID, IAreaRepository _context)
    {
        var response = new APIResponse();
        try
        {
            
            var areas = await _context.GetAllAsync(storageID);
            if (areas.Any())
            {
                response.Success(areas);
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
        
        return Results.BadRequest(response);
    }
    private static async Task<IResult> AddAreaByStorageId(int storageId, [FromBody] AreaDTO areaDTO, IAreaRepository _context)
    {
        var response = new APIResponse();

        var area = areaDTO.toEntity();
        try
        {
            await _context.AddAsync(storageId, area);
            await _context.SaveChangesAsync();
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
    private static async Task<IResult> GetAreaByStorageId(int storaegeID, int areaID, IAreaRepository _context) 
    {
        var response = new APIResponse();

        try
        {
            var area = await _context.GetByIdAsync(storaegeID, areaID);
            return Results.Ok(response.Success(area));
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
    private static async Task<IResult> RemoveAreaById(int storageId, [FromBody] AreaDTO areaDTO, IAreaRepository _context)
    {
        var response = new APIResponse();

        try
        {
            await _context.RemoveAsync(storageId, areaDTO.Id);
            await _context.SaveChangesAsync();
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
