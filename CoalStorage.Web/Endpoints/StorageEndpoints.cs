using CoalStorage.Core.Common;
using CoalStorage.Core.Interfaces;
using System.Data.Common;
using CoalStorage.Core.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using CoalStorage.Core.Entities;
using CoalStorage.Core.Entities.DTO;
namespace CoalStorage.Web.Endpoints
{
    public static class StorageEndpoints
    {
        public static void ConfigureStorageEndpoints(this WebApplication app)
        {

            app.MapGet("api/storages", GetAllStorages);
            app.MapGet("api/storage/{id:int}", GetStorageById);
            app.MapPost("api/storage", CreateStorage);
            app.MapDelete("api/storage", RemoveStorage);
            app.MapPut("api/storage", UpdateStorage);
        }

        private static async Task<IResult> UpdateStorage(IStorageRepository _context)
        {
            
            throw new NotImplementedException();

        }

        private static async Task<IResult> RemoveStorage(IStorageRepository _context)
        {
            throw new NotImplementedException();
        }


        private static async Task<IResult> GetStorageById(IStorageRepository _context, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> CreateStorage(IStorageRepository _context, [FromBody] MainStorageDTO storage)
        {
            var response = new APIResponse();

            try
            {
                await _context.AddAsync(storage.toEntity());
                await _context.SaveChangesAsync();
                response.Created(storage);
                return Results.Ok(response);
            }
            catch (DbException dbEx)
            {
                response.dbException(dbEx);
                return Results.BadRequest(response);
            }
            catch (Exception ex)
            {
                response.fatalException(ex);
                return Results.BadRequest(response);
            }
        }

        private static async Task<IResult> GetAllStorages(IStorageRepository _context)
        {
            var response = new APIResponse();

            try
            {
                var artists = await _context.GetAllAsync();
                response.Success(artists);

                return Results.Ok(response);
            }
            catch (DbException dbEx)
            {
                response.dbException(dbEx);
                return Results.BadRequest(response);
            }
            catch (Exception ex)
            {
                response.fatalException(ex);
                return Results.BadRequest(response);
            }
        }
    }
}
