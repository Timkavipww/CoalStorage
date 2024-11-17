namespace CoalStorage.API.Endpoints;

public static class AreaEndpoints
{
    public static void AddAreaEndpoints(this WebApplication app)
    {
        app.MapGet("/api/storage/{id:int}/areas", GetAllAreaByStorageId);
        //app.MapGet("/api/storage/{id:int}/areas/{areaId:int}", GetAreaByStorageId)
            //.WithDescription("get area by storage id");
        //app.MapPost("/api/storage/{id:int}/areas", AddAreaByStorageId);
    }
    private static async Task<IResult> GetAllAreaByStorageId(IAreaRepository _context)
    {
        var response = new APIResponse();
        try
        {
            
            var areas = await _context.GetAllAreasAsync();
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
   
} 