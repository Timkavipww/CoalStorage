using CoalStorage.Core.Common;
using CoalStorage.Core.Common.Extensions;
using CoalStorage.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace CoalStorage.API.Endpoints
{
    public static class AuthEndpoints
    {
        public static void AddAuthEndpoints(this WebApplication app)
        {
            // Регистрируем маршрут для авторизации, перенаправляющий на AuthController
            app.MapPost("/api/auth", (LoginModel model, [FromServices] ITokenService tokenService) => AuthUser(model, tokenService));
        }

        // Метод для аутентификации, принимающий LoginModel и ITokenService
        private static async Task<IResult> AuthUser(LoginModel loginModel, ITokenService tokenService)
        {
            var response = new APIResponse();
            try
            {
                // Генерация токена с помощью tokenService
                var token = tokenService.GenerateToken(loginModel.Username, loginModel.Password);

                if (token == null)
                {
                    // Если токен не сгенерирован, возвращаем 401
                    return Results.Unauthorized();
                }

                // Если токен сгенерирован, возвращаем его в ответе
                return Results.Ok(new { Token = token });
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
