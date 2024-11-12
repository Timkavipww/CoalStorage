using CoalStorage.Core.Common;
using CoalStorage.Core.Interfaces;
using CoalStorage.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoalStorage.API.Services
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Генерация токена с помощью вашего сервиса
            var token = _tokenService.GenerateToken(model.Username, model.Password);

            if (token == null)
            {
                // Возвращаем ответ с кодом 401 (Unauthorized), если токен не был сгенерирован
                return Unauthorized("Invalid credentials");
            }

            // Возвращаем токен в объекте OK (200) в случае успешной авторизации
            return Ok(new { Token = token });
        }
    }
}