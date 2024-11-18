using CoalStorage.Core.Entities;

namespace CoalStorage.API.Endpoints;

public static class AreaEndpoints
{
    public static void AddAreaEndpoints(this WebApplication app)
    {
        app.MapGet("/api/area/{storageId:int}", GetAllAreaByStorageId);
        app.MapGet("api/areas", GetAllAreasAsync);
        //app.MapPost("/api/storage/{id:int}/areas", AddAreaByStorageId);
        app.MapDelete("/api/areas/{areaId:int}", RemoveAreaById);
        app.MapPost("api/areas", CreateAreaToMainStorage);
    }
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
    private static async Task<IResult> GetAllAreasAsync(IAreaRepository _context)
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

    private static async Task<IResult> RemoveAreaById(long Id, IAreaRepository _context)
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
    private static async Task<IResult> CreateAreaToMainStorage([FromBody] AreaCreateDTO areaFromBody, IAreaRepository _context)
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

} 